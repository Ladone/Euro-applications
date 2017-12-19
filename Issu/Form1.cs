using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using System.Text.RegularExpressions;
using Word = Microsoft.Office.Interop.Word;
using Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;
using Issu.Libs;

namespace Issu
{
    public partial class IndexForm : Form
    {
        public IndexForm()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            qualificationRb.ReadOnly = true;
            generateBtn.Enabled = false;

            // Инициализация формы
            disciplinesCountLbl.Text = String.Format("Кількість дисциплін: 0");
            numberOfGraduatesLbl.Text = String.Format("Кількість випускників: 0");
        }

        // Инициализация словарей
        //private Dictionary<int, string> students = new Dictionary<int, string>();
        private Dictionary<int, Student> students = new Dictionary<int, Student>();
        private Dictionary<int, string> filesPath = new Dictionary<int, string>();
        private Dictionary<string, string> serviceValues = new Dictionary<string, string>();
        private Dictionary<int, StringMultiLanguage> programSpecification = new Dictionary<int, StringMultiLanguage>();
        private Dictionary<int, StringMultiLanguage> knowledgeUnderstanding = new Dictionary<int, StringMultiLanguage>();
        private Dictionary<int, StringMultiLanguage> applyingKnowledge = new Dictionary<int, StringMultiLanguage>();


        private HSSFWorkbook hssfwb;

        private StringMultiLanguage qualification = new StringMultiLanguage();
        private StringMultiLanguage studyQualification = new StringMultiLanguage();
        private StringMultiLanguage levelQualification = new StringMultiLanguage();
        private StringMultiLanguage durationProgram = new StringMultiLanguage();
        private StringMultiLanguage accessRequiments = new StringMultiLanguage();

        private string modeStudy = "";





        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void authorBtn_Click(object sender, EventArgs e)
        {
            AuthorForm af = new AuthorForm();
            af.Show();
        }



        private void авторToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AuthorForm af = new AuthorForm();
            af.Show();
        }

        private void вихідToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void loadExcellFileBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excell table Microsoft Office 1998-2003 (*.xls)|*.xls";
            Stream myStream = null;
            int disciplinesCount = 0;
            int numberOfGraduatesCount = 0;
            processPb.Value = 0;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    excellFileLoadStatusPb.Image = Issu.Properties.Resources.On;
                    DateTime localDate = DateTime.Now;
                    rbStatus.Text += String.Format("{0}:{1}:{2}: Файл даних \"Excell\" успішно завантажено.\n", localDate.Hour, localDate.Minute, localDate.Second);

                    filesPath.Add(0, ofd.FileName); // Добавление файлового пути
                    using (FileStream file = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read))
                    {
                        hssfwb = new HSSFWorkbook(file);
                    }

                    // Получение листов из Excell
                    ISheet sheet0 = hssfwb.GetSheetAt(0);
                    ISheet sheet1 = hssfwb.GetSheetAt(1);
                    ISheet sheet2 = hssfwb.GetSheetAt(2);
                    ISheet sheet3 = hssfwb.GetSheetAt(3);

                    ISheet sheet5 = hssfwb.GetSheetAt(5);

                    var qualificationCR = new CellReference("B1");
                    var qualificationRow = sheet1.GetRow(qualificationCR.Row);
                    serviceValues.Add("qualification", qualificationRow.GetCell(qualificationCR.Col).ToString());

                    var trainingDirectionCR = new CellReference("B3");
                    var trainingDirectionRow = sheet1.GetRow(trainingDirectionCR.Row);
                    var trainingDirectionCell = trainingDirectionRow.GetCell(trainingDirectionCR.Col);

                    qualification.UA = sheet1.GetRow(0).GetCell(1).StringCellValue;
                    qualification.EN = sheet1.GetRow(1).GetCell(1).StringCellValue;

                    studyQualification.UA = sheet1.GetRow(2).GetCell(1).StringCellValue;
                    studyQualification.EN = sheet1.GetRow(3).GetCell(1).StringCellValue;

                    levelQualification.UA = sheet2.GetRow(0).GetCell(1).StringCellValue;
                    levelQualification.EN = sheet2.GetRow(1).GetCell(1).StringCellValue;

                    durationProgram.UA = sheet2.GetRow(2).GetCell(1).StringCellValue;
                    durationProgram.EN = sheet2.GetRow(3).GetCell(1).StringCellValue;

                    accessRequiments.UA = sheet2.GetRow(4).GetCell(1).StringCellValue;
                    accessRequiments.EN = sheet2.GetRow(5).GetCell(1).StringCellValue;

                    for (int row = 1; row <= sheet5.LastRowNum; row++)
                    {
                        if (sheet5.GetRow(row) != null && sheet5.GetRow(row).GetCell(0).StringCellValue.Length > 2 && sheet5.GetRow(row).GetCell(0).StringCellValue != " ") //null is when the row only contains empty cells 
                        {
                            rbStatus.Text += string.Format("Row {0} = {1}\n", row, sheet5.GetRow(row).GetCell(0).StringCellValue);
                            disciplinesCount++;
                        }
                    }

                    //MessageBox.Show(sheet0.LastRowNum.ToString());
                    // Обработка листа 0
                    for (int row = 1; row <= sheet0.LastRowNum; row++)
                    {
                        if (sheet0.GetRow(row) != null) //null is when the row only contains empty cells 
                        {
                            string studentNameUA = sheet0.GetRow(row).GetCell(0).StringCellValue;
                            string studentNameEN = sheet0.GetRow(row).GetCell(1).StringCellValue;
                            string firstnameUA = sheet0.GetRow(row).GetCell(2).StringCellValue;
                            string firstnameEN = sheet0.GetRow(row).GetCell(3).StringCellValue;
                            DateTime birthday = DateTime.FromOADate(sheet0.GetRow(row).GetCell(4).NumericCellValue);


                            string studentNamePattern = @"\s+";
                            Regex srg = new Regex(studentNamePattern);
                            studentNameUA = srg.Replace(studentNameUA, "");

                            // Создание обьекта студент
                            Student student = new Student();
                            student.Lastname.UA = studentNameUA;
                            student.Lastname.EN = studentNameEN;
                            student.Firstname.UA = firstnameUA;
                            student.Firstname.EN = firstnameEN;
                            student.Birthday = birthday;

                            students.Add(row, student);
                            rbStatus.Text += string.Format("Row {0} = {1}\n", row, sheet0.GetRow(row).GetCell(0).StringCellValue);
                            numberOfGraduatesCount++;
                        }
                    }

                    // Обработка листа 3
                    modeStudy = sheet3.GetRow(1).GetCell(0).StringCellValue;
                    MessageBox.Show("Я");

                    for (int row = 1; row < sheet3.LastRowNum; row++)
                    {
                        if (sheet3.GetRow(row).GetCell(1) != null && sheet3.GetRow(row).GetCell(2) != null) {
                            if (!string.IsNullOrEmpty(sheet3.GetRow(row).GetCell(1).StringCellValue) && !string.IsNullOrEmpty(sheet3.GetRow(row).GetCell(2).StringCellValue))
                            {
                                string programspcUA = sheet3.GetRow(row).GetCell(1).StringCellValue;
                                string programspcEN = sheet3.GetRow(row).GetCell(2).StringCellValue;

                                programSpecification.Add(row, new StringMultiLanguage(programspcUA, programspcEN));
                            }
                        }
                        if (sheet3.GetRow(row).GetCell(3) != null && sheet3.GetRow(row).GetCell(4) != null)
                        {
                            if (!string.IsNullOrEmpty(sheet3.GetRow(row).GetCell(3).StringCellValue) && !string.IsNullOrEmpty(sheet3.GetRow(row).GetCell(4).StringCellValue))
                            {
                                string knowledgeUnderstandingUA = sheet3.GetRow(row).GetCell(3).StringCellValue;
                                string knowledgeUnderstandingEN = sheet3.GetRow(row).GetCell(4).StringCellValue;

                                knowledgeUnderstanding.Add(row, new StringMultiLanguage(knowledgeUnderstandingUA, knowledgeUnderstandingEN));
                            }
                        }
                        if (sheet3.GetRow(row).GetCell(3) != null && sheet3.GetRow(row).GetCell(4) != null)
                        {
                            if (!string.IsNullOrEmpty(sheet3.GetRow(row).GetCell(5).StringCellValue) && !string.IsNullOrEmpty(sheet3.GetRow(row).GetCell(6).StringCellValue))
                            {
                                string applyingKnowledgeUA = sheet3.GetRow(row).GetCell(5).StringCellValue;
                                string applyingKnowledgeEN = sheet3.GetRow(row).GetCell(6).StringCellValue;

                                applyingKnowledge.Add(row, new StringMultiLanguage(applyingKnowledgeUA, applyingKnowledgeEN));
                            }
                        }
                    }

                    // render
                    qualificationRb.Text = String.Format("{0}", serviceValues["qualification"]);
                    disciplinesCountLbl.Text = String.Format("Кількість дисциплін: {0}", disciplinesCount);
                    numberOfGraduatesLbl.Text = String.Format("Кількість випускників: {0}", numberOfGraduatesCount);
                    trainingDirectionRb.Text = String.Format("{0}", trainingDirectionCell);
                    processPb.Maximum = numberOfGraduatesCount;

                    // enabled buttons
                    generateBtn.Enabled = true;


                    foreach (KeyValuePair<int, Student> student in students)
                    {
                        rbStatus.Text += string.Format("{0}: {1}", student.Key, student.Value);
                    }

                }
                catch (Exception exc)
                {
                    DateTime localDate = DateTime.Now;
                    rbStatus.Text += String.Format("{0}:{1}:{2}: Помилка: \n{3}\n", localDate.Hour, localDate.Minute, localDate.Second, exc.Message);
                    disciplinesCount = 0;
                    numberOfGraduatesCount = 0;
                    processPb.Value = 0;
                    processPb.Maximum = 0;
                }
            }


        }

        private void loadDocFileBtn_Click(object sender, EventArgs e)
        {
            docLoadStatusPb.Image = Issu.Properties.Resources.On;
            rbStatus.Text += "Click\n";
            //Word.Application MSWord = new Word.Application();

            //Word.Document Doc = MSWord.Documents.Open(@"D:\1.doc",  ReadOnly:true);

            //rbStatus.Text = Doc.Content.Text;
            //MSWord.Quit();
            //MessageBox.Show(value+" НУ ШОООООООООООООО?");


            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Word Microsoft Office 1998-2003 (*.doc)|*.doc";
            Stream myStream = null;
            int disciplinesCount = 0;
            int numberOfGraduatesCount = 0;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    excellFileLoadStatusPb.Image = Issu.Properties.Resources.On;
                    DateTime localDate = DateTime.Now;
                    rbStatus.Text += String.Format("{0}:{1}:{2}: Файл даних \"Word\" успішно завантажено.\n", localDate.Hour, localDate.Minute, localDate.Second);

                    filesPath.Add(1, ofd.FileName); // Добавление файлового пути


                }
                catch (Exception exc)
                {
                    DateTime localDate = DateTime.Now;
                    rbStatus.Text += String.Format("{0}:{1}:{2}: Помилка: \n{3}\n", localDate.Hour, localDate.Minute, localDate.Second, exc.Message);
                }
            }


        }

        private void clearStatusConsoleLbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            rbStatus.Text = "";
        }

        private void generateBtn_Click(object sender, EventArgs e)
        {
            DateTime localDate = DateTime.Now;

            if (!Directory.Exists("./output"))
            {
                rbStatus.Text += String.Format("{0}:{1}:{2}: Було створено папку \"Output\".\n", localDate.Hour, localDate.Minute, localDate.Second);
                Directory.CreateDirectory("output");
            }
            //MessageBox.Show("1");
            string pattern = @"[\s|\.|,]+";
            Regex rgx = new Regex(pattern);
            string directory = rgx.Replace(serviceValues["qualification"], "_");

            if (!Directory.Exists(String.Format("./output/{0}", directory)))
            {
                rbStatus.Text += String.Format("{0}:{1}:{2}: Було створено папку \"{3}\".\n", localDate.Hour, localDate.Minute, localDate.Second, directory);
                Directory.CreateDirectory(String.Format("./output/{0}", directory));
            }

            rbStatus.Text += "test";
            int increment = 1;


            generateEuroAddEuroSupplement(directory, increment, students);
        }

        private void generateEuroAddEuroSupplement(string directory, int increment, Dictionary<int, Student> students)
        {
            if (students.Count >= increment)
            {
                DateTime localDate = DateTime.Now;

                if (!Directory.Exists(String.Format("./output/{0}/{1}", directory, students[increment])))
                {
                    rbStatus.Text += String.Format("{0}:{1}:{2}: Було створено папку \"{3}\".\n", localDate.Hour, localDate.Minute, localDate.Second, students[increment]);
                }

                Directory.CreateDirectory(String.Format("./output/{0}/{1}", directory, students[increment].Lastname.UA));
                try
                {
                    File.Copy(filesPath[1], String.Format("./output/{0}/{1}/{1}.doc", directory, students[increment].Lastname.UA), true);
                }
                catch (Exception exc)
                {
                    rbStatus.Text += String.Format("{0}:{1}:{2}: Помилка: \n{3}\n", localDate.Hour, localDate.Minute, localDate.Second, exc.Message);
                }

                Word.Application MSWord = new Word.Application();
                rbStatus.Text += String.Format("./output/\nI{0}I\n/\nI{1}I\n/\nI{1}I\n.doc", directory, students[increment].Lastname.UA);
                Word.Document doc = MSWord.Documents.Open(Path.Combine(Environment.CurrentDirectory, "output", directory, students[increment].Lastname.UA, students[increment].Lastname.UA + ".doc"), ReadOnly: false, Visible: true);
                doc.Activate();

                FindAndReplace(MSWord, "{{lastname_UA}}", students[increment].Lastname.UA);
                FindAndReplace(MSWord, "{{lastname_EN}}", students[increment].Lastname.EN);
                FindAndReplace(MSWord, "{{firstname_UA}}", students[increment].Firstname.UA);
                FindAndReplace(MSWord, "{{firstname_EN}}", students[increment].Firstname.EN);
                FindAndReplace(MSWord, "{{birthday}}", String.Format("{0}.{1}.{2}", students[increment].Birthday.Day, students[increment].Birthday.Month, students[increment].Birthday.Year));
                FindAndReplace(MSWord, "{{qualification_UA}}", qualification.UA);
                FindAndReplace(MSWord, "{{qualification_EN}}", qualification.EN);
                FindAndReplace(MSWord, "{{studyQualification_UA}}", studyQualification.UA);
                FindAndReplace(MSWord, "{{studyQualification_EN}}", studyQualification.EN);
                FindAndReplace(MSWord, "{{levelQualification_UA}}", levelQualification.UA);
                FindAndReplace(MSWord, "{{levelQualification_EN}}", levelQualification.EN);
                FindAndReplace(MSWord, "{{durationProgram_UA}}", durationProgram.UA);
                FindAndReplace(MSWord, "{{durationProgram_EN}}", durationProgram.EN);
                FindAndReplace(MSWord, "{{accessRequiments_UA}}", accessRequiments.UA);
                FindAndReplace(MSWord, "{{accessRequiments_EN}}", accessRequiments.EN);
                FindAndReplace(MSWord, "{{modeStudy}}", modeStudy);

                for (int i = 1; i <= programSpecification.Count; i++)
                {

                    if (i < programSpecification.Count)
                    {
                        FindAndReplace(MSWord, "{{programSpecification_UA}}", string.Format("{0}^p{{{{programSpecification_UA}}}}", programSpecification[i].UA));
                        FindAndReplace(MSWord, "{{programSpecification_EN}}", string.Format("{0}^p{{{{programSpecification_EN}}}}", programSpecification[i].EN));
                    }

                    if (i == programSpecification.Count)
                    {
                        FindAndReplace(MSWord, "{{programSpecification_UA}}", programSpecification[i].UA);
                        FindAndReplace(MSWord, "{{programSpecification_EN}}", programSpecification[i].EN);
                    }
                }

                for (int i = 1; i <= knowledgeUnderstanding.Count; i++)
                {

                    if (i < knowledgeUnderstanding.Count)
                    {
                        FindAndReplace(MSWord, "{{knowledgeUnderstanding_UA}}", string.Format("{0}^p{{{{knowledgeUnderstanding_UA}}}}", knowledgeUnderstanding[i].UA));
                        FindAndReplace(MSWord, "{{knowledgeUnderstanding_EN}}", string.Format("{0}^p{{{{knowledgeUnderstanding_EN}}}}", knowledgeUnderstanding[i].EN));
                    }

                    if (i == knowledgeUnderstanding.Count)
                    {
                        FindAndReplace(MSWord, "{{knowledgeUnderstanding_UA}}", knowledgeUnderstanding[i].UA);
                        FindAndReplace(MSWord, "{{knowledgeUnderstanding_EN}}", knowledgeUnderstanding[i].EN);
                    }
                }

                //for (int i = 1; i < knowledgeUnderstanding.Count; i++)
                //{

                //    if (i < knowledgeUnderstanding.Count)
                //    {
                //        FindAndReplace(MSWord, "{{knowledgeUnderstanding_UA}}", string.Format("{0}^p{{{{knowledgeUnderstanding_UA}}}}", knowledgeUnderstanding[i].UA));
                //        FindAndReplace(MSWord, "{{knowledgeUnderstanding_EN}}", knowledgeUnderstanding[i].EN);
                //    }

                //    if (i == knowledgeUnderstanding.Count)
                //    {
                //        FindAndReplace(MSWord, "{{knowledgeUnderstanding_UA}}", knowledgeUnderstanding[i].UA);
                //        FindAndReplace(MSWord, "{{knowledgeUnderstanding_EN}}", knowledgeUnderstanding[i].EN);
                //    }
                //}

                for (int i = 1; i < applyingKnowledge.Count; i++)
                {
                    FindAndReplace(MSWord, "{{applyingKnowledge_UA}}", applyingKnowledge[i].UA);
                    FindAndReplace(MSWord, "{{applyingKnowledge_EN}}", applyingKnowledge[i].EN);
                }

                

                //rbStatus.Text = Doc.Content.Text;
                doc.Save();
                MSWord.Quit();
                rbStatus.Text += Path.Combine("./output/{0}/{1}/{1}.doc", directory, students[increment].Lastname.UA);
                rbStatus.Text += Path.Combine(Environment.CurrentDirectory, directory, students[increment].Lastname.UA, students[increment] + ".doc");
                processPb.Value = increment;
                percentStatusLbl.Text = String.Format("{0}/{1}", increment, students.Count);
                increment++;

                generateEuroAddEuroSupplement(directory, increment, students);
            }
            
            if(students.Count == increment)
            {
                MessageBox.Show("Готово", "Статус обробки");
            }
        }


        private void FindAndReplace(Microsoft.Office.Interop.Word.Application doc, string findText, string replaceWithText)
        {
            if (replaceWithText.Length > 255)
            {
                FindAndReplace(doc, findText, findText + replaceWithText.Substring(255));
                replaceWithText = replaceWithText.Substring(0, 255);
            }

            //options
            object matchCase = false;
            object matchWholeWord = true;
            object matchWildCards = false;
            object matchSoundsLike = false;
            object matchAllWordForms = false;
            object forward = true;
            object format = false;
            object matchKashida = false;
            object matchDiacritics = false;
            object matchAlefHamza = false;
            object matchControl = false;
            object read_only = false;
            object visible = true;
            object replace = 2;
            object wrap = 1;

            //execute find and replace
            doc.Selection.Find.Execute(findText, ref matchCase, ref matchWholeWord,
                ref matchWildCards, ref matchSoundsLike, ref matchAllWordForms, ref forward, ref wrap, ref format, replaceWithText, ref replace,
                ref matchKashida, ref matchDiacritics, ref matchAlefHamza, ref matchControl);
        }
    }
}
