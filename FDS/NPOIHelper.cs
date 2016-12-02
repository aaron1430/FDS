using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Web;
using NPOI;
using NPOI.HPSF;
using NPOI.HSSF;
using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.POIFS;
using NPOI.Util;
using NPOI.SS.UserModel;
using NPOI.SS.Util;


public class NPOIHelper
{
    /// <summary>
    /// DataTable导出到Excel文件
    /// </summary>
    /// <param name="dtSource">源DataTable</param>
    /// <param name="strHeaderText">表头文本</param>
    /// <param name="strFileName">保存位置</param>
    /// <Author>柳永法 http://www.yongfa365.com/ 2010-5-8 22:21:41</Author>
    /// <remarks>包阿儒汉 修改于2015-06-05 适应NPOI 2.0beta版本</remarks>
    public static bool Export(DataTable dtSource, string strHeaderText, string strFileName)
    {
        using (MemoryStream ms = Export(dtSource, strHeaderText))
        {
            using (FileStream fs = new FileStream(strFileName, FileMode.Create, FileAccess.Write))
            {
                byte[] data = ms.ToArray();
                fs.Write(data, 0, data.Length);
                fs.Flush();
                return true;
            }
        }
    }

    /// <summary>
    /// DataTable导出到Excel的MemoryStream
    /// </summary>
    /// <param name="dtSource">源DataTable</param>
    /// <param name="strHeaderText">表头文本</param>
    /// <Author>柳永法 http://www.yongfa365.com/ 2010-5-8 22:21:41</Author>
    public static MemoryStream Export(DataTable dtSource, string strHeaderText)
    {
        HSSFWorkbook workbook = new HSSFWorkbook();
        ISheet sheet = workbook.CreateSheet();

        #region 右击文件 属性信息
        {
            DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
            dsi.Company = "http://www.yongfa365.com/";
            workbook.DocumentSummaryInformation = dsi;

            SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
            si.Author = "西安联通"; //填加xls文件作者信息
            si.ApplicationName = "水电房租管理系统"; //填加xls文件创建程序信息
            si.LastAuthor = ""; //填加xls文件最后保存者信息
            si.Comments = ""; //填加xls文件作者信息
            si.Title = ""; //填加xls文件标题信息
            si.Subject = "";//填加文件主题信息
            si.CreateDateTime = DateTime.Now;
            workbook.SummaryInformation = si;
        }
        #endregion

        //取得列宽
        int[] arrColWidth = new int[dtSource.Columns.Count];
        foreach (DataColumn item in dtSource.Columns)
        {
            arrColWidth[item.Ordinal] = Encoding.GetEncoding(936).GetBytes(item.ColumnName.ToString()).Length;
        }
        for (int i = 0; i < dtSource.Rows.Count; i++)
        {
            for (int j = 0; j < dtSource.Columns.Count; j++)
            {
                int intTemp = Encoding.GetEncoding(936).GetBytes(dtSource.Rows[i][j].ToString()).Length;
                if (intTemp > arrColWidth[j])
                {
                    if (intTemp > 12)
                    {
                        arrColWidth[j] = 12;
                    }
                    else
                    {
                        arrColWidth[j] = intTemp;
                    }
                }
            }
        }


        //数据内容样式
        int rowIndex = 0;
        ICellStyle CellStyle = workbook.CreateCellStyle();
        CellStyle.WrapText = true;
        CellStyle.Alignment = HorizontalAlignment.Left;//居中 
        CellStyle.VerticalAlignment = VerticalAlignment.Center;//垂直居中
        CellStyle.BorderBottom = BorderStyle.Thin;
        CellStyle.BorderLeft = BorderStyle.Thin;
        CellStyle.BorderRight = BorderStyle.Thin;
        CellStyle.BorderTop = BorderStyle.Thin;

        //表格名称样式
        ICellStyle TitleStyle = workbook.CreateCellStyle();
        TitleStyle.Alignment = HorizontalAlignment.Center;
        TitleStyle.VerticalAlignment = VerticalAlignment.Center;
        IFont font = workbook.CreateFont();
        font.FontHeightInPoints = 12;
        font.Boldweight = 700;
        TitleStyle.SetFont(font);
        TitleStyle.BorderBottom = BorderStyle.Thin;
        TitleStyle.BorderLeft = BorderStyle.Thin;
        TitleStyle.BorderRight = BorderStyle.Thin;
        TitleStyle.BorderTop = BorderStyle.Thin;

        //表头样式
        ICellStyle headStyle = workbook.CreateCellStyle();
        headStyle.Alignment = HorizontalAlignment.Center;
        headStyle.VerticalAlignment = VerticalAlignment.Center;
        headStyle.WrapText = true;
        IFont headFont = workbook.CreateFont();
        headFont.FontHeightInPoints = 10;
        headFont.Boldweight = 700;
        headStyle.SetFont(headFont);
        headStyle.BorderBottom = BorderStyle.Thin;
        headStyle.BorderLeft = BorderStyle.Thin;
        headStyle.BorderRight = BorderStyle.Thin;
        headStyle.BorderTop = BorderStyle.Thin;
        headStyle.FillPattern = FillPattern.SolidForeground;////设置背景颜色,这两行配合设置
        headStyle.FillForegroundColor = HSSFColor.Grey25Percent.Index;


        ICellStyle dateStyle = workbook.CreateCellStyle();
        dateStyle.Alignment = HorizontalAlignment.Left;
        dateStyle.VerticalAlignment = VerticalAlignment.Center;
        IDataFormat format = workbook.CreateDataFormat();
        dateStyle.DataFormat = format.GetFormat("yyyy-mm-dd");
        dateStyle.BorderBottom = BorderStyle.Thin;
        dateStyle.BorderLeft = BorderStyle.Thin;
        dateStyle.BorderRight = BorderStyle.Thin;
        dateStyle.BorderTop = BorderStyle.Thin;



        foreach (DataRow row in dtSource.Rows)
        {
            #region 新建表，填充表头，填充列头，样式
            if (rowIndex == 65535 || rowIndex == 0)
            {
                if (rowIndex != 0)
                {
                    sheet = workbook.CreateSheet();
                }

                #region 表头及样式
                {
                    IRow headerRow = sheet.CreateRow(0);
                    headerRow.HeightInPoints = 25;
                    headerRow.CreateCell(0).SetCellValue(strHeaderText);


                    headerRow.GetCell(0).CellStyle = TitleStyle;

                    sheet.AddMergedRegion(new CellRangeAddress(0, 0, 0, dtSource.Columns.Count - 1));
                    //headerRow.Dispose();
                }
                #endregion


                #region 列头及样式
                {
                    if (rowIndex < 2)
                    {
                        IRow headerRow = sheet.CreateRow(1);
                        headerRow.HeightInPoints = 25;
                        foreach (DataColumn column in dtSource.Columns)
                        {
                            headerRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);
                            headerRow.GetCell(column.Ordinal).CellStyle = headStyle;
                            //设置列宽
                            sheet.SetColumnWidth(column.Ordinal, (arrColWidth[column.Ordinal] + 1) * 256);
                        }
                        //headerRow.Dispose();
                    }
                }
                #endregion

                rowIndex = 2;
            }
            #endregion


            #region 填充内容
            IRow dataRow = sheet.CreateRow(rowIndex);

            foreach (DataColumn column in dtSource.Columns)
            {
                ICell newCell = dataRow.CreateCell(column.Ordinal);
                newCell.CellStyle = CellStyle;
                string drValue = row[column].ToString();
                switch (column.DataType.ToString())
                {
                    case "System.String"://字符串类型
                        newCell.SetCellValue(drValue);
                        break;
                    case "System.DateTime"://日期类型
                        DateTime dateV;
                        DateTime.TryParse(drValue, out dateV);
                        newCell.SetCellValue(dateV);

                        newCell.CellStyle = dateStyle;//格式化显示
                        break;
                    case "System.Boolean"://布尔型
                        bool boolV = false;
                        bool.TryParse(drValue, out boolV);
                        newCell.SetCellValue(boolV);
                        break;
                    case "System.Int16"://整型
                    case "System.Int32":
                    case "System.Int64":
                    case "System.Byte":
                        int intV = 0;
                        int.TryParse(drValue, out intV);
                        newCell.SetCellValue(intV);
                        break;
                    case "System.Decimal"://浮点型
                    case "System.Double":
                    case "System.Single":
                        double doubV = 0;
                        double.TryParse(drValue, out doubV);
                        newCell.SetCellValue(doubV);
                        break;
                    case "System.DBNull"://空值处理
                        newCell.SetCellValue("");
                        break;
                    default:
                        newCell.SetCellValue("");
                        break;
                }

            }
            #endregion

            rowIndex++;
        }

        sheet.ForceFormulaRecalculation = true;
        sheet.PrintSetup.PaperSize = 9;
        sheet.PrintSetup.Landscape = true;
        sheet.PrintSetup.FitHeight = 3000;
        sheet.PrintSetup.FitWidth = 3000;

        using (MemoryStream ms = new MemoryStream())
        {
            workbook.Write(ms);
            ms.Flush();
            ms.Position = 0;

            //sheet.Dispose();
            //workbook.Dispose();//一般只用写这一个就OK了，他会遍历并释放所有资源，但当前版本有问题所以只释放sheet
            return ms;
        }

    }



    /// <summary>读取excel
    /// 默认第一行为标头
    /// </summary>
    /// <param name="strFileName">excel文档路径</param>
    /// <returns></returns>
    public static DataTable Import(string strFileName)
    {
        DataTable dt = new DataTable();

        HSSFWorkbook hssfworkbook;
        using (FileStream file = new FileStream(strFileName, FileMode.Open, FileAccess.Read))
        {
            hssfworkbook = new HSSFWorkbook(file);
        }
        ISheet sheet = hssfworkbook.GetSheetAt(0);
        System.Collections.IEnumerator rows = sheet.GetRowEnumerator();

        IRow headerRow = sheet.GetRow(0);
        int cellCount = headerRow.LastCellNum;

        for (int j = 0; j < cellCount; j++)
        {
            ICell cell = headerRow.GetCell(j);
            dt.Columns.Add(cell.ToString());
        }

        for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
        {
            IRow row = sheet.GetRow(i);
            DataRow dataRow = dt.NewRow();

            for (int j = row.FirstCellNum; j < cellCount; j++)
            {
                if (row.GetCell(j) != null)
                    dataRow[j] = row.GetCell(j).ToString();
            }

            dt.Rows.Add(dataRow);
        }
        return dt;
    }

}