using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Com.Garfield.Payment.model;
using Com.Garfield.Utility;

namespace Com.Garfield.Payment.common
{
    public class PdfHelper
    {
        ////private Section _section;
        private Font font = null;
        private PdfWriter pdfWriter = null;
        private List<Tb_PaymentApply> data = null;//凭证数据

        public void PdfTest(List<Tb_PaymentApply> lstCashFlowData)
        {
            try
            {
                data = lstCashFlowData;

                if (data == null || data.Count == 0) throw new Exception("未查询到凭证数据！");

                Document document = new Document(PageSize.A4, 5f, 5f, 0.5f, 0.5f);
                pdfWriter = PdfWriter.GetInstance(document, new FileStream("./files/Payment.pdf", FileMode.Create));
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
                    document.Add(CreateHeaderTable(1, data[i]));
                    document.Add(CreateMainTable(data[i]));
                    document.Add(CreateFooterTable(1, data[i]));

                    if (i + 1 < data.Count)
                    {
                        document.Add(CreateHeaderTable(2, data[i + 1]));
                        document.Add(CreateMainTable(data[i + 1]));
                        document.Add(CreateFooterTable(2, data[i + 1]));

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
        private Table CreateHeaderTable(int flag, Tb_PaymentApply data)
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

            /*标题*/
            font = PdfFontHelper.SetFont("楷体", 22);
            table.AddCell(CreateCell("付款申请单\r", false), 0, 1);

            /*申请部门*/
            font = PdfFontHelper.SetFont("楷体", 13);
            if (string.IsNullOrEmpty(data.DepartMent)) data.DepartMent = "       ";
            table.AddCell(CreateCell($"申请部门：{data.DepartMent}", false, 1, 1, Element.ALIGN_LEFT, Element.ALIGN_MIDDLE), 1, 0);

            /*凭证日期*/
            font = PdfFontHelper.SetFont("楷体", 13);
            var _applyDate = DateTime.Now;
            if (!DateTime.TryParse(data.ApplyDate.ToShortDateString(), out _applyDate)) _applyDate = DateTime.Now;
            var _year = _applyDate.Year;
            var _month = _applyDate.Month;
            var _day = _applyDate.Day;
            table.AddCell(CreateCell($"申请日期：{_year} 年 {_month} 月 {_day} 日", false), 1, 1);

            /*付款申请单号*/
            font = PdfFontHelper.SetFont("楷体", 13);
            if (string.IsNullOrEmpty(data.BillNo)) data.BillNo = "       ";
            table.AddCell(CreateCell($"单号：{data.BillNo}", false, 1, 1, Element.ALIGN_RIGHT, Element.ALIGN_MIDDLE), 1, 2);

            return table;
        }

        /// <summary>
        /// 创建凭证主体信息
        /// </summary>
        /// <param name="data"></param>
        /// <param name="dataDetails"></param>
        /// <returns></returns>
        private Table CreateMainTable(Tb_PaymentApply data)
        {
            var _widths = new float[4] { 1.5f, 3f, 1.5f, 3f };
            var table = new Table(4);
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

            font = PdfFontHelper.SetFont("楷体", 13);
            var cell = CreateCell("\r摘  要：\n\r", true, 1, 1, Element.ALIGN_RIGHT, Element.ALIGN_MIDDLE);
            table.AddCell(cell, 0, 0);
            table.AddCell(CreateCell(data.Summary, true, 1, 3, Element.ALIGN_LEFT, Element.ALIGN_MIDDLE), 0, 1);
            table.AddCell(CreateCell("本月总费用：", true, 1, 1, Element.ALIGN_RIGHT, Element.ALIGN_MIDDLE), 1, 0);
            table.AddCell(CreateCell($"￥：{data.TotalMonthCost.ToString("#0.00")}", true, 1, 1, Element.ALIGN_LEFT, Element.ALIGN_MIDDLE), 1, 1);
            table.AddCell(CreateCell("已付金额：", true, 1, 1, Element.ALIGN_RIGHT, Element.ALIGN_MIDDLE), 1, 2);
            table.AddCell(CreateCell($"￥：{data.PaidAmount.ToString("#0.00")}", true, 1, 1, Element.ALIGN_LEFT, Element.ALIGN_MIDDLE), 1, 3);

            table.AddCell(CreateCell("付款金额：", true, 1, 1, Element.ALIGN_RIGHT, Element.ALIGN_MIDDLE), 2, 0);
            table.AddCell(CreateCell($"人民币(大写)：{data.AmountToPayUpper}   ￥：{data.AmountToPay.ToString("#0.00")}", true, 1, 3, Element.ALIGN_LEFT, Element.ALIGN_MIDDLE), 2, 1);

            table.AddCell(CreateCell("付款方式：", true, 1, 1, Element.ALIGN_RIGHT, Element.ALIGN_MIDDLE), 3, 0);
            var _payType = data.PayType.Split(';');
            var _lstPayType = new List<string>() { "现金", "汇款", "现金支票", "转账支票" };
            var _payTypeTemp = string.Empty;
            foreach (var item in _lstPayType)
            {
                if (_payType.Contains(item))
                {
                    _payTypeTemp += $"■ {item}    ";
                }
                else
                {
                    _payTypeTemp += $"□ {item}    ";
                }
            }
            table.AddCell(CreateCell(_payTypeTemp, true, 1, 3, Element.ALIGN_LEFT, Element.ALIGN_MIDDLE), 3, 1);

            //font = PdfFontHelper.SetFont("楷体", 10);
            //table.AddCell(CreateCell("付款人/银行/账号：", true, 1, 1, Element.ALIGN_RIGHT, Element.ALIGN_MIDDLE), 4, 0);
            table.AddCell(CreateCell("付款账号：", true, 1, 1, Element.ALIGN_RIGHT, Element.ALIGN_MIDDLE), 4, 0);
            var _payAccount = data.PayAccount.Split(';');
            var _lstPayAccount = new List<string>() { "工行7578#", "农行2673#", "中生2631#", "GY微信" };
            var _payAccountTemp = string.Empty;
            foreach (var item in _lstPayAccount)
            {
                if (_payAccount.Contains(item))
                {
                    _payAccountTemp += $"■ {item}    ";
                }
                else
                {
                    _payAccountTemp += $"□ {item}    ";
                }
            }
            font = PdfFontHelper.SetFont("楷体", 13);
            table.AddCell(CreateCell(_payAccountTemp, true, 1, 3, Element.ALIGN_LEFT, Element.ALIGN_MIDDLE), 4, 1);

            font = PdfFontHelper.SetFont("楷体", 13);
            //table.AddCell(CreateCell("收款单位/收款人：", true), 5, 0);
            table.AddCell(CreateCell("收款单位：", true, 1, 1, Element.ALIGN_RIGHT, Element.ALIGN_MIDDLE), 5, 0);

            font = PdfFontHelper.SetFont("楷体", 13);
            table.AddCell(CreateCell($"{data.Payee}", true, 1, 2, Element.ALIGN_LEFT, Element.ALIGN_MIDDLE), 5, 1);
            table.AddCell(CreateCell($"收款人电话：{data.PayeePhone}", true, 1, 1, Element.ALIGN_LEFT, Element.ALIGN_MIDDLE), 5, 3);

            font = PdfFontHelper.SetFont("楷体", 13);
            table.AddCell(CreateCell("收款单位\r账号：", true, 1, 1, Element.ALIGN_RIGHT, Element.ALIGN_MIDDLE), 6, 0);
            font = PdfFontHelper.SetFont("楷体", 13);
            table.AddCell(CreateCell($"{data.PayeeAccount}", true, 1, 3, Element.ALIGN_LEFT, Element.ALIGN_MIDDLE), 6, 1);

            font = PdfFontHelper.SetFont("楷体", 13);
            table.AddCell(CreateCell("收款单位\r银行：", true, 1, 1, Element.ALIGN_RIGHT, Element.ALIGN_MIDDLE), 7, 0);
            font = PdfFontHelper.SetFont("楷体", 13);
            table.AddCell(CreateCell($"{data.PayeeBank}", true, 1, 3, Element.ALIGN_LEFT, Element.ALIGN_MIDDLE), 7, 1);

            font = PdfFontHelper.SetFont("楷体", 13);
            table.AddCell(CreateCell("出纳确认\r汇出金额：", true, 1, 1, Element.ALIGN_RIGHT, Element.ALIGN_MIDDLE), 8, 0);

            font = PdfFontHelper.SetFont("楷体", 13);
            table.AddCell(CreateCell($"￥：{data.ExportAmount.ToString("#0.00")}", true, 1, 1, Element.ALIGN_LEFT, Element.ALIGN_MIDDLE), 8, 1);
            table.AddCell(CreateCell($"手续费：{data.Poundage.ToString("#0.00")}", true, 1, 1, Element.ALIGN_LEFT, Element.ALIGN_MIDDLE), 8, 2);
            table.AddCell(CreateCell($"汇出日期：{Convert.ToDateTime(data.ExportDate).ToShortDateString()}", true, 1, 1, Element.ALIGN_LEFT, Element.ALIGN_MIDDLE), 8, 3);

            table.AddCell(CreateCell("备注：", true, 1, 1, Element.ALIGN_RIGHT, Element.ALIGN_MIDDLE), 9, 0);
            table.AddCell(CreateCell(data.Remark, true, 1, 3, Element.ALIGN_LEFT, Element.ALIGN_MIDDLE), 9, 1);

            return table;
        }

        /// <summary>
        /// 创建凭证尾部
        /// </summary>
        /// <param name="flag"></param>
        /// <param name="data"></param>
        /// <param name="dataDetails"></param>
        /// <returns></returns>
        private Table CreateFooterTable(int flag, Tb_PaymentApply data)
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

            font = PdfFontHelper.SetFont("楷体", 13);
            var _blank = string.Empty;
            if (flag == 1) _blank = "\n\r\n\r";
            else _blank = "";
            table.AddCell(CreateCell($"总经理：  {"    "}{_blank}", true, 1, 1, Element.ALIGN_LEFT), 0, 0);
            table.AddCell(CreateCell($"副理：  {"    "}{_blank}", true, 1, 1, Element.ALIGN_LEFT), 0, 1);
            table.AddCell(CreateCell($"复核人：  {"    "}{_blank}", true, 1, 1, Element.ALIGN_LEFT), 0, 2);
            table.AddCell(CreateCell($"经办人：  {"    "}{_blank}", true, 1, 1, Element.ALIGN_LEFT), 0, 3);
            table.AddCell(CreateCell($"出纳：  {"    "}{_blank}", true, 1, 1, Element.ALIGN_LEFT), 0, 4);

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
