using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using admin.model;
using NPOI.HSSF.Util;
using NPOI.SS.UserModel;
using WebApp.DB.marykay;

namespace WebApp.admin.MaryKay
{
    public partial class KoreaManage : System.Web.UI.Page
    {
        MaryKayDBEntities _db = new MaryKayDBEntities();
        List<RecordModel> list = new List<RecordModel>();
        public int i = 0;

        public int PageIndex
        {
            get { return Convert.ToInt32(ViewState["PageIndex"]); }
            set { ViewState["PageIndex"] = value; }
        }
        private int NumCount;//总条数
        //年龄段
        public int PageCount = 10;//每页显示的条数

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string formatString = "欢迎您使用本系统！";
                PageIndex = 1;
                LoadFirstQData();
            }
        }
        public void LoadFirstQData()
        {
            marykay_Set s = (from a in _db.marykay_Set
                             where a.sId == 3
                             select a).FirstOrDefault();
            if (s.sIsOpen == true)
            {
                btnQuestion.Text = "关闭问卷";
            }
            else
            {
                btnQuestion.Text = "开启问卷";
            }
            marykay_Set s2 = (from a in _db.marykay_Set
                              where a.sId == 4
                              select a).FirstOrDefault();
            if (s2.sIsOpen == true)
            {
                btnPhoto.Text = "关闭照片";
            }
            else
            {
                btnPhoto.Text = "开启照片";
            }
            PageIndex = 1;
            list = (from r in _db.korea_record
                    join emp in _db.korea_employeeMK on new { EId = r.eId.Value } equals new { EId = emp.eId }
                    join ans in
                        (
                            (from a in _db.korea_answer
                             group a by new
                             {
                                 a.rId
                             } into g
                             select new
                             {
                                 arid = g.Key.rId.Value,
                                 answer1 = g.Max(p => (p.qId == 1 ? p.aContent : null)),
                                 answer2 = g.Max(p => (p.qId == 2 ? p.aContent : null)),
                                 answer3 = g.Max(p => (p.qId == 3 ? p.aContent : null)),
                                 answer4 = g.Max(p => (p.qId == 4 ? p.aContent : null)),
                                 answer5 = g.Max(p => (p.qId == 5 ? p.aContent : null)),
                                 answer6 = g.Max(p => (p.qId == 6 ? p.aContent : null)),
                                 answer7 = g.Max(p => (p.qId == 7 ? p.aContent : null)),
                                 answer8 = g.Max(p => (p.qId == 8 ? p.aContent : null)),
                                 answer9 = g.Max(p => (p.qId == 9 ? p.aContent : null)),
                                 answer10 = g.Max(p => (p.qId == 10 ? p.aContent : null)),
                                 answer11 = g.Max(p => (p.qId == 11 ? p.aContent : null)),
                                 answer12 = g.Max(p => (p.qId == 12 ? p.aContent : null))
                             })) on new { RId = r.rId } equals new { RId = ans.arid }
                    orderby
                      r.rId
                    select new RecordModel
                    {
                        AnswerId = r.rId,
                        AnswerName = emp.eName,
                        AnswerNumber = emp.eNumber,
                        AnswerPhone = emp.ePhone,
                        AnswerDuration = r.rDuration.Value,
                        AnswerTime = r.rEndtime.Value,
                        AnswerAnswer1 = ans.answer1,
                        AnswerAnswer2 = ans.answer2,
                        AnswerAnswer3 = ans.answer3,
                        AnswerAnswer4 = ans.answer4,
                        AnswerAnswer5 = ans.answer5,
                        AnswerAnswer6 = ans.answer6,
                        AnswerAnswer7 = ans.answer7,
                        AnswerAnswer8 = ans.answer8,
                        AnswerAnswer9 = ans.answer9,
                        AnswerAnswer10 = ans.answer10,
                        AnswerAnswer11 = ans.answer11,
                        AnswerAnswer12 = ans.answer12,
                    }).Skip(PageCount * (PageIndex - 1)).Take(PageCount).ToList();

            lblIndex.InnerText = (PageIndex).ToString();
            lblCount.InnerText = (nuCount()).ToString();
            repTaskInfo.DataSource = list;
            repTaskInfo.DataBind();


            var sumEmp = (from b in _db.korea_employeeMK select b).ToList().Count();
            lblSumCount.Text = "当前总人数为:" + sumEmp + "，已答题人数<span style='color:red; margin:0 8px;'>" + list.Count + "</span>位。";

            btnFrist.Enabled = true;
            btnPrv.Enabled = true;
            btnLast.Enabled = true;
            btnNext.Enabled = true;
            if (PageIndex == 1)
            {
                btnPrv.Enabled = false;
                btnFrist.Enabled = false;
            }
            if (PageIndex == nuCount())
            {
                btnNext.Enabled = false;
                btnLast.Enabled = false;
            }
        }
        #region 分页
        List<RecordModel> getCases(int pageIndex, int pageCount)
        {
            btnFrist.Enabled = true;
            btnPrv.Enabled = true;
            btnLast.Enabled = true;
            btnNext.Enabled = true;
            if (pageIndex == 1)
            {
                btnPrv.Enabled = false;
                btnFrist.Enabled = false;
            }
            if (pageIndex == nuCount())
            {
                btnNext.Enabled = false;
                btnLast.Enabled = false;
            }
            list = (from r in _db.korea_record
                    join emp in _db.korea_employeeMK on new { EId = r.eId.Value } equals new { EId = emp.eId }
                    join ans in
                        (
                            (from a in _db.korea_answer
                             group a by new
                             {
                                 a.rId
                             } into g
                             select new
                             {
                                 arid = g.Key.rId.Value,
                                 answer1 = g.Max(p => (p.qId == 1 ? p.aContent : null)),
                                 answer2 = g.Max(p => (p.qId == 2 ? p.aContent : null)),
                                 answer3 = g.Max(p => (p.qId == 3 ? p.aContent : null)),
                                 answer4 = g.Max(p => (p.qId == 4 ? p.aContent : null)),
                                 answer5 = g.Max(p => (p.qId == 5 ? p.aContent : null)),
                                 answer6 = g.Max(p => (p.qId == 6 ? p.aContent : null)),
                                 answer7 = g.Max(p => (p.qId == 7 ? p.aContent : null)),
                                 answer8 = g.Max(p => (p.qId == 8 ? p.aContent : null)),
                                 answer9 = g.Max(p => (p.qId == 9 ? p.aContent : null)),
                                 answer10 = g.Max(p => (p.qId == 10 ? p.aContent : null)),
                                 aremark4 = g.Max(p => (p.qId == 4 ? p.aRemark : null)),
                                 aremark6 = g.Max(p => (p.qId == 6 ? p.aRemark : null))
                             })) on new { RId = r.rId } equals new { RId = ans.arid }
                    orderby
                      r.rId
                    select new RecordModel
                    {
                        AnswerId = r.rId,
                        AnswerName = emp.eName,
                        AnswerNumber = emp.eNumber,
                        AnswerPhone = emp.ePhone,
                        AnswerDuration = r.rDuration.Value,
                        AnswerTime = r.rEndtime.Value,
                        AnswerAnswer1 = ans.answer1,
                        AnswerAnswer2 = ans.answer2,
                        AnswerAnswer3 = ans.answer3,
                        AnswerAnswer4 = ans.answer4,
                        AnswerAnswer5 = ans.answer5,
                        AnswerAnswer6 = ans.answer6,
                        AnswerAnswer7 = ans.answer7,
                        AnswerAnswer8 = ans.answer8,
                        AnswerAnswer9 = ans.answer9,
                        AnswerAnswer10 = ans.answer10,
                        AnswerAnswer11 = ans.aremark4,
                        AnswerAnswer12 = ans.aremark6,
                    }).Skip(PageCount * (PageIndex - 1)).Take(PageCount).ToList();

            lblIndex.InnerText = (pageIndex).ToString();
            lblCount.InnerText = (nuCount()).ToString();
            return list;
        }
        //总页数
        public int nuCount()
        {
            NumCount = (from r in _db.korea_record
                        join emp in _db.korea_employeeMK on new { EId = r.eId.Value } equals new { EId = emp.eId }
                        join ans in
                            (
                                (from a in _db.korea_answer
                                 group a by new
                                 {
                                     a.rId
                                 } into g
                                 select new
                                 {
                                     arid = g.Key.rId.Value,
                                     answer1 = g.Max(p => (p.qId == 1 ? p.aContent : null)),
                                     answer2 = g.Max(p => (p.qId == 2 ? p.aContent : null)),
                                     answer3 = g.Max(p => (p.qId == 3 ? p.aContent : null)),
                                     answer4 = g.Max(p => (p.qId == 4 ? p.aContent : null)),
                                     answer5 = g.Max(p => (p.qId == 5 ? p.aContent : null)),
                                     answer6 = g.Max(p => (p.qId == 6 ? p.aContent : null)),
                                     answer7 = g.Max(p => (p.qId == 7 ? p.aContent : null)),
                                     answer8 = g.Max(p => (p.qId == 8 ? p.aContent : null)),
                                     answer9 = g.Max(p => (p.qId == 9 ? p.aContent : null)),
                                     answer10 = g.Max(p => (p.qId == 10 ? p.aContent : null)),
                                     aremark4 = g.Max(p => (p.qId == 4 ? p.aRemark : null)),
                                     aremark6 = g.Max(p => (p.qId == 6 ? p.aRemark : null))
                                 })) on new { RId = r.rId } equals new { RId = ans.arid }
                        orderby
                          r.rId
                        select new RecordModel
                        {
                            AnswerId = r.rId,
                            AnswerName = emp.eName,
                            AnswerNumber = emp.eNumber,
                            AnswerPhone = emp.ePhone,
                            AnswerDuration = r.rDuration.Value,
                            AnswerTime = r.rEndtime.Value,
                            AnswerAnswer1 = ans.answer1,
                            AnswerAnswer2 = ans.answer2,
                            AnswerAnswer3 = ans.answer3,
                            AnswerAnswer4 = ans.answer4,
                            AnswerAnswer5 = ans.answer5,
                            AnswerAnswer6 = ans.answer6,
                            AnswerAnswer7 = ans.answer7,
                            AnswerAnswer8 = ans.answer8,
                            AnswerAnswer9 = ans.answer9,
                            AnswerAnswer10 = ans.answer10,
                            AnswerAnswer11 = ans.aremark4,
                            AnswerAnswer12 = ans.aremark6,
                        }
                         ).Count();
            int num = NumCount / PageCount;
            if (NumCount % PageCount != 0 || NumCount == 0)
            {
                num++;
            }
            return num;
        }
        //第一页
        protected void btnFrist_Click(object sender, EventArgs e)
        {
            PageIndex = 1;

            list = getCases(PageIndex, PageCount);
            repTaskInfo.DataSource = list;
            repTaskInfo.DataBind();
        }
        //上一页
        protected void btnPrv_Click(object sender, EventArgs e)
        {
            PageIndex--;

            list = getCases(PageIndex, PageCount);
            repTaskInfo.DataSource = list;
            repTaskInfo.DataBind();
        }
        //下一页
        protected void btnNext_Click(object sender, EventArgs e)
        {
            PageIndex++;

            list = getCases(PageIndex, PageCount);
            repTaskInfo.DataSource = list;
            repTaskInfo.DataBind();
        }
        //最后一页
        protected void btnLast_Click(object sender, EventArgs e)
        {

            PageIndex = nuCount();

            list = getCases(PageIndex, PageCount);
            repTaskInfo.DataSource = list;
            repTaskInfo.DataBind();

        }
        #endregion
        protected void btnExport_Click(object sender, EventArgs e)
        {
            string tip = CreateExcel();
            if (tip == "Error1")
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('导出格式错误');</script>");

            }
            else if (tip == "Error2")
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('没有数据');</script>");
            }
            else
            {
                Response.Redirect(tip);
            }
        }

        /// <summary>
        /// 导出问卷数据
        /// </summary>
        /// <param name="list"></param>
        public string CreateExcel()
        {
            list = (from r in _db.korea_record
                    join emp in _db.korea_employeeMK on new { EId = r.eId.Value } equals new { EId = emp.eId }
                    join ans in
                        (
                            (from a in _db.korea_answer
                             group a by new
                             {
                                 a.rId
                             } into g
                             select new
                             {
                                 arid = g.Key.rId.Value,
                                 answer1 = g.Max(p => (p.qId == 1 ? p.aContent : null)),
                                 answer2 = g.Max(p => (p.qId == 2 ? p.aContent : null)),
                                 answer3 = g.Max(p => (p.qId == 3 ? p.aContent : null)),
                                 answer4 = g.Max(p => (p.qId == 4 ? p.aContent : null)),
                                 answer5 = g.Max(p => (p.qId == 5 ? p.aContent : null)),
                                 answer6 = g.Max(p => (p.qId == 6 ? p.aContent : null)),
                                 answer7 = g.Max(p => (p.qId == 7 ? p.aContent : null)),
                                 answer8 = g.Max(p => (p.qId == 8 ? p.aContent : null)),
                                 answer9 = g.Max(p => (p.qId == 9 ? p.aContent : null)),
                                 answer10 = g.Max(p => (p.qId == 10 ? p.aContent : null)),
                                 answer11 = g.Max(p => (p.qId == 11 ? p.aContent : null)),
                                 answer12 = g.Max(p => (p.qId == 12 ? p.aContent : null))
                             })) on new { RId = r.rId } equals new { RId = ans.arid }
                    orderby
                      r.rId
                    select new RecordModel
                    {
                        AnswerId = r.rId,
                        AnswerName = emp.eName,
                        AnswerNumber = emp.eNumber,
                        AnswerPhone = emp.ePhone,
                        AnswerDuration = r.rDuration.Value,
                        AnswerTime = r.rEndtime.Value,
                        AnswerAnswer1 = ans.answer1,
                        AnswerAnswer2 = ans.answer2,
                        AnswerAnswer3 = ans.answer3,
                        AnswerAnswer4 = ans.answer4,
                        AnswerAnswer5 = ans.answer5,
                        AnswerAnswer6 = ans.answer6,
                        AnswerAnswer7 = ans.answer7,
                        AnswerAnswer8 = ans.answer8,
                        AnswerAnswer9 = ans.answer9,
                        AnswerAnswer10 = ans.answer10,
                        AnswerAnswer11 = ans.answer11,
                        AnswerAnswer12 = ans.answer12,
                    }
                         ).ToList();

            if (list != null && list.Count > 0)  //
            {

                try
                {
                    NPOI.HSSF.UserModel.HSSFWorkbook book = new NPOI.HSSF.UserModel.HSSFWorkbook();
                    NPOI.SS.UserModel.ISheet sheet = book.CreateSheet("问卷数据下载");
                    //
                    NPOI.SS.UserModel.IRow rowHeader = sheet.CreateRow(0);
                    sheet.SetColumnWidth(0, 12 * 256);
                    sheet.SetColumnWidth(1, 10 * 256);
                    sheet.SetColumnWidth(2, 15 * 256);
                    sheet.SetColumnWidth(3, 18 * 256);
                    sheet.SetColumnWidth(4, 20 * 256);
                    sheet.SetColumnWidth(5, 25 * 256);
                    ICellStyle style = book.CreateCellStyle();
                    HSSFColor color = new HSSFColor.BLACK();
                    FillPatternType fillPattern = FillPatternType.SOLID_FOREGROUND;//灰色背景
                    HSSFColor backGround = new HSSFColor.GREY_25_PERCENT();
                    IFont font = ExportData.GetFontStyle(book, "宋体", color, 11);
                    //设置单元格的样式：水平对齐居中
                    style = ExportData.GetCellStyle(book, font, fillPattern, backGround, HorizontalAlignment.CENTER, VerticalAlignment.CENTER);


                    ICell cell1 = rowHeader.CreateCell(0);
                    cell1.SetCellValue("姓名");
                    //将新的样式赋给单元格
                    cell1.CellStyle = style;

                    ICell cell2 = rowHeader.CreateCell(1);
                    cell2.SetCellValue("编号");
                    cell2.CellStyle = style;

                    ICell cell3 = rowHeader.CreateCell(2);
                    cell3.SetCellValue("手机号码");
                    cell3.CellStyle = style;

                    ICell cell4 = rowHeader.CreateCell(3);
                    cell4.SetCellValue("第1题");
                    cell4.CellStyle = style;

                    ICell cell5 = rowHeader.CreateCell(4);
                    cell5.SetCellValue("第2题");
                    cell5.CellStyle = style;

                    ICell cell6 = rowHeader.CreateCell(5);
                    cell6.SetCellValue("第3题");
                    cell6.CellStyle = style;

                    ICell cell7 = rowHeader.CreateCell(6);
                    cell7.SetCellValue("第4题");
                    cell7.CellStyle = style;

                    ICell cell8 = rowHeader.CreateCell(7);
                    cell8.SetCellValue("第5题");
                    cell8.CellStyle = style;

                    ICell cell9 = rowHeader.CreateCell(8);
                    cell9.SetCellValue("第6题");
                    cell9.CellStyle = style;

                    ICell cell10 = rowHeader.CreateCell(9);
                    cell10.SetCellValue("第7题");
                    cell10.CellStyle = style;
                    ICell cell11 = rowHeader.CreateCell(10);
                    cell11.SetCellValue("第8题");
                    cell11.CellStyle = style;

                    ICell cell12 = rowHeader.CreateCell(11);
                    cell12.SetCellValue("第9题");
                    cell12.CellStyle = style;

                    ICell cell13 = rowHeader.CreateCell(12);
                    cell13.SetCellValue("第10题");
                    cell13.CellStyle = style;

                    ICell cell14 = rowHeader.CreateCell(13);
                    cell14.SetCellValue("第11题");
                    cell14.CellStyle = style;

                    ICell cell15 = rowHeader.CreateCell(14);
                    cell15.SetCellValue("第12题");
                    cell15.CellStyle = style;

                    ICellStyle cellStyle = book.CreateCellStyle();
                    cellStyle.Alignment = HorizontalAlignment.CENTER;
                    cellStyle.VerticalAlignment = VerticalAlignment.CENTER;
                    IFont rowfont = book.CreateFont();
                    rowfont.FontName = "宋体";
                    rowfont.FontHeightInPoints = (short)11;
                    rowfont.Color = color.GetIndex();
                    cellStyle.SetFont(rowfont);
                    //
                    NPOI.SS.UserModel.IRow row = null;
                    for (int i = 0; i < list.Count; i++)
                    {
                        RecordModel model = list[i];
                        row = sheet.CreateRow(i + 1);
                        ICell rowcell1 = row.CreateCell(0);
                        rowcell1.SetCellValue(model.AnswerName);
                        rowcell1.CellStyle = cellStyle;
                        ICell rowcell2 = row.CreateCell(1);
                        rowcell2.SetCellValue(model.AnswerNumber);
                        rowcell2.CellStyle = cellStyle;

                        ICell rowcell3 = row.CreateCell(2);
                        rowcell3.SetCellValue(model.AnswerPhone);
                        rowcell3.CellStyle = cellStyle;

                        ICell rowcell4 = row.CreateCell(3);
                        rowcell4.SetCellValue(model.AnswerAnswer1);
                        rowcell4.CellStyle = cellStyle;

                        ICell rowcell5 = row.CreateCell(4);
                        rowcell5.SetCellValue(model.AnswerAnswer2);
                        rowcell5.CellStyle = cellStyle;

                        ICell rowcell6 = row.CreateCell(5);
                        rowcell6.SetCellValue(model.AnswerAnswer3);
                        rowcell6.CellStyle = cellStyle;


                        ICell rowcell7 = row.CreateCell(6);
                        rowcell7.SetCellValue(model.AnswerAnswer4);
                        rowcell7.CellStyle = cellStyle;

                        ICell rowcell8 = row.CreateCell(7);
                        rowcell8.SetCellValue(model.AnswerAnswer5);
                        rowcell8.CellStyle = cellStyle;

                        ICell rowcell9 = row.CreateCell(8);
                        rowcell9.SetCellValue(model.AnswerAnswer6);
                        rowcell9.CellStyle = cellStyle;

                        ICell rowcell10 = row.CreateCell(9);
                        rowcell10.SetCellValue(model.AnswerAnswer7);
                        rowcell10.CellStyle = cellStyle;

                        ICell rowcell11 = row.CreateCell(10);
                        rowcell11.SetCellValue(model.AnswerAnswer8);
                        rowcell11.CellStyle = cellStyle;
                        ICell rowcell12 = row.CreateCell(11);
                        rowcell12.SetCellValue(model.AnswerAnswer9);
                        rowcell12.CellStyle = cellStyle;
                        ICell rowcell13 = row.CreateCell(12);
                        rowcell13.SetCellValue(model.AnswerAnswer10);
                        rowcell13.CellStyle = cellStyle;
                        ICell rowcell14 = row.CreateCell(13);
                        rowcell14.SetCellValue(model.AnswerAnswer11);
                        rowcell14.CellStyle = cellStyle;

                        ICell rowcell15 = row.CreateCell(14);
                        rowcell15.SetCellValue(model.AnswerAnswer12);
                        rowcell15.CellStyle = cellStyle;
                    }
                    //  
                    using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                    {

                        book.Write(ms);

                        //string path = @"C:\Users\DNS\Desktop\导出参会人";
                        //string path = System.Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\数据导出Excel";
                        // path = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\数据导出Excel";
                        string path = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "Data\\";
                        DirectoryInfo excelDir = new DirectoryInfo(path);
                        //如果路径不存在就创建
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }
                        string fileName = "mk_q" + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
                        //string strDate = DateTime.Now.ToString("yyyy-MM-dd-HH "); 

                        path = excelDir.FullName + fileName;
                        if (File.Exists(path))
                        {
                            File.Delete(path);
                        }
                        using (Stream localFile = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                        {
                            //ms.ToArray()转换为字节数组就是想要的图片源字节
                            localFile.Write(ms.ToArray(), 0, (int)ms.Length);
                        }
                        book = null;
                        ms.Close();
                        ms.Dispose();
                        //
                        string webAddress = System.Configuration.ConfigurationManager.AppSettings["mkDataPath"].ToString();

                        return webAddress + fileName;
                    }
                }
                catch (Exception)
                {
                    //Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('导出格式错误');</script>");
                    return "Error1";
                }
            }
            else
            {
                return "Error2";
            }
        }

        protected void btnSelectPro1_Click(object sender, EventArgs e)
        {
            LoadFirstQData();
        }
        protected void btnQuestion_Click(object sender, EventArgs e)
        {
            marykay_Set s = (from a in _db.marykay_Set
                             where a.sId == 3
                             select a).FirstOrDefault();
            if (btnQuestion.Text == "开启问卷")
            {

                s.sIsOpen = true;
                _db.SaveChanges();
                btnQuestion.Text = "关闭问卷";
            }
            else
            {
                s.sIsOpen = false;
                _db.SaveChanges();
                btnQuestion.Text = "开启问卷";
            }
        }

        protected void btnPhoto_Click(object sender, EventArgs e)
        {
            marykay_Set s = (from a in _db.marykay_Set
                             where a.sId == 4
                             select a).FirstOrDefault();
            if (btnPhoto.Text == "开启照片")
            {

                s.sIsOpen = true;
                _db.SaveChanges();
                btnPhoto.Text = "关闭照片";
            }
            else
            {
                s.sIsOpen = false;
                _db.SaveChanges();
                btnPhoto.Text = "开启照片";
            }
        }
    }
}