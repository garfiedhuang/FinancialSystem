using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Com.Garfield.CashFlow.model;
using Com.Garfield.Utility;

namespace Com.Garfield.CashFlow.common
{
    public class PdfHelper
    {
        //private Section _section;
        private Font font = null;
        private PdfWriter pdfWriter = null;
        private List<CashFlowData> data = null;//凭证数据

        public void PdfTest(List<CashFlowData> lstCashFlowData)
        {
            try
            {
                data = lstCashFlowData;

                if (data == null || data.Count == 0) throw new Exception("未查询到凭证数据！");

                Document document = new Document(PageSize.A4, 5f, 5f, 0.5f, 0.5f);
                pdfWriter = PdfWriter.GetInstance(document, new FileStream("./files/CashFlow.pdf", FileMode.Create));
                document.Open();
                //document.AddTitle("AddTitle");
                //document.AddSubject("AddSubject");
                //document.AddKeywords("AddKeywords");
                //document.AddAuthor("AddAuthor");
                //document.AddCreator("AddCreator");
                //document.AddProducer();
                //document.AddCreationDate();
                //document.AddHeader("Header","Header Content");
                //document.Add(new Paragraph("Hello World"));

                for (var i = 0; i < data.Count; i++)
                {
                    document.Add(CreateHeaderTable(1, data[i].CashFlow, data[i].CashFlowDetails));
                    document.Add(CreateMainTable(data[i].CashFlow, data[i].CashFlowDetails));
                    document.Add(CreateFooterTable(1, data[i].CashFlow, data[i].CashFlowDetails));

                    if (i + 1 < data.Count)
                    {
                        document.Add(CreateHeaderTable(2, data[i+1].CashFlow, data[i+1].CashFlowDetails));
                        document.Add(CreateMainTable(data[i+1].CashFlow, data[i+1].CashFlowDetails));
                        document.Add(CreateFooterTable(2, data[i+1].CashFlow, data[i+1].CashFlowDetails));

                        //另起一页
                        document.NewPage();

                        i++;
                    }
                }
                document.Close();
            }
            finally { }
        }

        /// <summary>
        /// 创建凭证头部
        /// </summary>
        /// <param name="flag"></param>
        /// <param name="data"></param>
        /// <param name="dataDetails"></param>
        /// <returns></returns>
        private Table CreateHeaderTable(int flag, TD_CASHFLOW data, List<TD_CASHFLOW_DETAIL> dataDetails)
        {
            var table = new Table(3);
            table.Border = Rectangle.NO_BORDER;
            table.DefaultCellBorder = Rectangle.NO_BORDER;
            table.Width = 100f;
            table.Widths = new float[3] { 2.5f, 5f, 2.5f };
            table.AutoFillEmptyCells = true;
            table.TableFitsPage = true;
            table.CellsFitPage = true;
            table.Cellpadding = 22f;
            table.Cellspacing = 20f;
            table.Padding = 1f;
            table.Spacing = 2f;
            table.Offset = 3.5f;

            /*凭证标题*/
            font = PdfFontHelper.SetFont("楷体", 20);
            table.AddCell(CreateCell("记   账   凭   证\r", false), 0, 1);

            if (flag == 1)
            {
                PdfContentByte cb = pdfWriter.DirectContent;
                cb.SetLineWidth(0.5f);//设置虚线大小 
                cb.SetLineCap(1);
                cb.MoveTo(150, 797);//线的起始位置 
                cb.LineTo(450, 797);//线的结束位置 
                cb.Stroke();

                PdfContentByte cb1 = pdfWriter.DirectContent;
                cb1.SetLineWidth(0.5f);//设置虚线大小 
                cb1.SetLineCap(1);
                cb1.MoveTo(150, 799);//线的起始位置 
                cb1.LineTo(450, 799);//线的结束位置 
                cb1.Stroke();
            }
            else
            {
                PdfContentByte cb = pdfWriter.DirectContent;
                cb.SetLineWidth(0.5f);//设置虚线大小 
                cb.SetLineCap(1);
                cb.MoveTo(150, 370);//线的起始位置 
                cb.LineTo(450, 370);//线的结束位置 
                cb.Stroke();

                PdfContentByte cb1 = pdfWriter.DirectContent;
                cb1.SetLineWidth(0.5f);//设置虚线大小 
                cb1.SetLineCap(1);
                cb1.MoveTo(150, 372);//线的起始位置 
                cb1.LineTo(450, 372);//线的结束位置 
                cb1.Stroke();
            }

            //font = PdfFontHelper.SetFont("楷体", 0.05f);
            //table.AddCell(CreateCell("", false, 1, 3), 1, 0);

            /*凭证日期*/
            font = PdfFontHelper.SetFont("楷体", 12);
            var _voucherDate = DateTime.Now;
            if (!DateTime.TryParse(data.VoucherDate.ToShortDateString(), out _voucherDate)) _voucherDate = DateTime.Now;
            var _year = _voucherDate.Year;
            var _month = _voucherDate.Month;
            var _day = _voucherDate.Day;
            table.AddCell(CreateCell($"{_year} 年 {_month} 月 {_day} 日", false), 1, 1);

            /*凭证号*/
            font = PdfFontHelper.SetFont("楷体", 12);
            if (string.IsNullOrEmpty(data.VoucherNo)) data.VoucherNo = "       ";
            table.AddCell(CreateCell($"字第{data.VoucherNo}号", false, 1, 1, Element.ALIGN_RIGHT, Element.ALIGN_MIDDLE), 1, 2);

            return table;
        }

        /// <summary>
        /// 创建凭证主体信息
        /// </summary>
        /// <param name="data"></param>
        /// <param name="dataDetails"></param>
        /// <returns></returns>
        private Table CreateMainTable(TD_CASHFLOW data, List<TD_CASHFLOW_DETAIL> dataDetails)
        {
            var _widths = new float[29] { 4f, 3f, 3f, 0.06f,
                                                           0.36f, 0.36f, 0.36f, 0.36f, 0.36f, 0.36f, 0.36f, 0.36f, 0.36f, 0.36f, 0.36f, 0.06f,
                                                           0.36f, 0.36f, 0.36f, 0.36f, 0.36f, 0.36f, 0.36f, 0.36f, 0.36f, 0.36f, 0.36f, 0.06f,
                                                           0.5f };
            var table = new Table(29);
            table.Width = 100f;
            table.Widths = _widths;
            table.AutoFillEmptyCells = true;
            table.TableFitsPage = true;
            table.CellsFitPage = true;
            table.Cellpadding = 22f;
            table.Cellspacing = 20f;
            table.BorderWidth = 0.5f;
            table.Padding = 1f;
            table.Spacing = 2f;
            table.Offset = 3.5f;
            //table.DefaultCellBorderWidth = 0.5f;

            font = PdfFontHelper.SetFont("楷体", 12);
            table.AddCell(CreateCell("摘        要", true, 2), 0, 0);
            table.AddCell(CreateCell("会    计    科    目", true, 1, 2), 0, 1);
            table.AddCell(CreateCell("总  账  科  目", true), 1, 1);
            table.AddCell(CreateCell("明  细  科  目", true), 1, 2);
            table.AddCell(CreateCell("借  方  金  额", true, 1, 11), 0, 4);

            font = PdfFontHelper.SetFont("楷体", 8);
            table.AddCell(CreateCell("亿", true), 1, 4);
            table.AddCell(CreateCell("千", true), 1, 5);
            table.AddCell(CreateCell("百", true), 1, 6);
            table.AddCell(CreateCell("十", true), 1, 7);
            table.AddCell(CreateCell("万", true), 1, 8);
            table.AddCell(CreateCell("千", true), 1, 9);
            table.AddCell(CreateCell("百", true), 1, 10);
            table.AddCell(CreateCell("十", true), 1, 11);
            table.AddCell(CreateCell("元", true), 1, 12);
            table.AddCell(CreateCell("角", true), 1, 13);
            table.AddCell(CreateCell("分", true), 1, 14);

            font = PdfFontHelper.SetFont("楷体", 12);
            table.AddCell(CreateCell("贷  方  金  额", true, 1, 11), 0, 16);

            font = PdfFontHelper.SetFont("楷体", 8);
            table.AddCell(CreateCell("亿", true), 1, 16);
            table.AddCell(CreateCell("千", true), 1, 17);
            table.AddCell(CreateCell("百", true), 1, 18);
            table.AddCell(CreateCell("十", true), 1, 19);
            table.AddCell(CreateCell("万", true), 1, 20);
            table.AddCell(CreateCell("千", true), 1, 21);
            table.AddCell(CreateCell("百", true), 1, 22);
            table.AddCell(CreateCell("十", true), 1, 23);
            table.AddCell(CreateCell("元", true), 1, 24);
            table.AddCell(CreateCell("角", true), 1, 25);
            table.AddCell(CreateCell("分", true), 1, 26);

            font = PdfFontHelper.SetFont("楷体", 7);
            table.AddCell(CreateCell("记账√", true, 2, 1), 0, 28);

            font = PdfFontHelper.SetFont("楷体", 25);
            table.AddCell(CreateCell("\n", true), 2, 3);
            table.AddCell(CreateCell("\n", true), 3, 3);
            table.AddCell(CreateCell("\n", true), 4, 3);
            table.AddCell(CreateCell("\n", true), 5, 3);
            table.AddCell(CreateCell("\n", true), 6, 3);
            table.AddCell(CreateCell("\n", true), 7, 3);
            table.AddCell(CreateCell("\n", true), 8, 3);
            table.AddCell(CreateCell("\n", true), 9, 3);
            table.AddCell(CreateCell("\n", true), 10, 3);
            table.AddCell(CreateCell("\n", true), 11, 3);

            for (int i=0;i< dataDetails.Count;i++)
            {
                font = PdfFontHelper.SetFont("楷体", 9);
                var cell = CreateCell(dataDetails[i].Summary, true, 1, 1, Element.ALIGN_LEFT);
                table.AddCell(cell, 2+i, 0);
                font = PdfFontHelper.SetFont("楷体", 11);
                table.AddCell(CreateCell(dataDetails[i].GeneralLedger, true, 1, 1, Element.ALIGN_LEFT), 2 + i, 1);
                table.AddCell(CreateCell(dataDetails[i].ClassificationItem, true, 1, 1, Element.ALIGN_LEFT), 2 + i, 2);

                font = PdfFontHelper.SetFont("楷体", 9);
                //借方金额
                var _temp = dataDetails[i].DebitAmount.ToString("#0.00").Replace(".", "").PadLeft(11, ' ');
                var _lstDebitAmount = _temp.ToCharArray();
                for (int j = 0; j < _lstDebitAmount.Length; j++)
                {
                    table.AddCell(CreateCell(_lstDebitAmount[j].ToString(), true, 1, 1, Element.ALIGN_LEFT), 2 + i, 4+j);
                }
                //贷方金额
                _temp = dataDetails[i].CreditAmount.ToString("#0.00").Replace(".", "").PadLeft(11, ' ');
                _lstDebitAmount = _temp.ToCharArray();
                for (int j = 0; j < _lstDebitAmount.Length; j++)
                {
                    table.AddCell(CreateCell(_lstDebitAmount[j].ToString(), true, 1, 1, Element.ALIGN_LEFT), 2 + i, 16 + j);
                }
            }

            font = PdfFontHelper.SetFont("楷体", 12);
            table.AddCell(CreateCell($"附件    {data.Attachment}    张", true), 11, 0);
            table.AddCell(CreateCell("合                  计", true, 1, 2), 11, 1);

            font = PdfFontHelper.SetFont("楷体", 9);
            //借方总金额
            var _temp2 = $"${data.TotalDebitAmount.ToString("#0.00").Replace(".", "")}".PadLeft(11, ' ');
            var _lstDebitAmount2 = _temp2.ToCharArray();
            for (int j = 0; j < _lstDebitAmount2.Length; j++)
            {
                table.AddCell(CreateCell(_lstDebitAmount2[j].ToString(), true, 1, 1, Element.ALIGN_LEFT), 11, 4 + j);
            }
            //贷方总金额
            _temp2 = $"${data.TotalCreditAmount.ToString("#0.00").Replace(".", "")}".PadLeft(11, ' ');
            _lstDebitAmount2 = _temp2.ToCharArray();
            for (int j = 0; j < _lstDebitAmount2.Length; j++)
            {
                table.AddCell(CreateCell(_lstDebitAmount2[j].ToString(), true, 1, 1, Element.ALIGN_LEFT), 11, 16 + j);
            }

            return table;
        }

        /// <summary>
        /// 创建凭证尾部
        /// </summary>
        /// <param name="flag"></param>
        /// <param name="data"></param>
        /// <param name="dataDetails"></param>
        /// <returns></returns>
        private Table CreateFooterTable(int flag, TD_CASHFLOW data, List<TD_CASHFLOW_DETAIL> dataDetails)
        {
            var table = new Table(5);
            table.Border = Rectangle.NO_BORDER;
            table.DefaultCellBorder = Rectangle.NO_BORDER;
            table.Width = 100f;
            table.Widths = new float[5] { 2f, 2f, 2f, 2f, 2f };
            table.AutoFillEmptyCells = true;
            table.TableFitsPage = true;
            table.CellsFitPage = true;
            table.Cellpadding = 22f;
            table.Cellspacing = 20f;
            table.Padding = 1f;
            table.Spacing = 2f;
            table.Offset = 3.5f;

            font = PdfFontHelper.SetFont("楷体", 12);
            var _blank = string.Empty;
            if (flag == 1) _blank = "\n\r";
            else _blank = "";
            table.AddCell(CreateCell($"会计主管  {data.AccountingSupervisor}{_blank}", true, 1, 1, Element.ALIGN_LEFT), 0, 0);
            table.AddCell(CreateCell($"记账  {data.Accounting}{_blank}", true, 1, 1, Element.ALIGN_LEFT), 0, 1);
            table.AddCell(CreateCell($"出纳  {data.Cashier}{_blank}", true, 1, 1, Element.ALIGN_LEFT), 0, 2);
            table.AddCell(CreateCell($"审核  {data.Auditing}{_blank}", true, 1, 1, Element.ALIGN_LEFT), 0, 3);
            table.AddCell(CreateCell($"制证  {data.Accreditation}{_blank}", true, 1, 1, Element.ALIGN_LEFT), 0, 4);

            return table;
        }

        /// <summary>
        /// 创建单元格
        /// </summary>
        /// <param name="content"></param>
        /// <param name="useAsCender"></param>
        /// <param name="rowspan"></param>
        /// <param name="colspan"></param>
        /// <param name="horizontalAlignment"></param>
        /// <param name="verticalAlignment"></param>
        /// <returns></returns>
        private Cell CreateCell(string content,
                                             bool useAsCender,
                                             int rowspan = 1,
                                             int colspan = 1,
                                             int horizontalAlignment = Element.ALIGN_CENTER,
                                             int verticalAlignment = Element.ALIGN_MIDDLE)
        {
            var cell = new Cell(new Paragraph(content, font));
            cell.Rowspan = rowspan;
            cell.Colspan = colspan;
            cell.HorizontalAlignment = horizontalAlignment;
            cell.VerticalAlignment = verticalAlignment;
            cell.UseAscender = useAsCender;
            return cell;
        }

    }
}
