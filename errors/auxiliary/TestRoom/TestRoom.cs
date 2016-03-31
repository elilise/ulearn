using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestingRoom
{
	public partial class TestRoom : Form
	{
		private readonly IEnumerable<TestCase> testCases;
		private Bitmap bitmap;
		private SplitterPanel pictureContainer;

		public TestRoom()
		{
			InitializeComponent();
			testCases = new TestCase[] {new FunnyTestcase("Тестовый тест-кейс"), new FunnyTestcase("Тестовый тест-кейс 2"),};
		}

		public TestRoom(IEnumerable<TestCase> testCases)
		{
			InitializeComponent();
			this.testCases = testCases;
		}

		private void TestRoom_Load(object sender, EventArgs e)
		{
			pictureContainer = pictureLogSplit.Panel1;
			pictureContainer.Resize += pictureContainer_Resize;
			pictureContainer.Paint += pictureContainer_Paint;
			UpdateListView();
		}

		private void RunAllTests()
		{
			foreach (ListViewItem item in testCasesList.Items)
			{
				item.Selected = true;
				Application.DoEvents();
			}
		}

		private void UpdateListView()
		{
			int selected = testCasesList.SelectedIndices.Count > 0 ? testCasesList.SelectedIndices[0] : -1;
			testCasesList.Clear();
			foreach (var testCase in testCases.Select((tc, i) => new {tc, i}))
				testCasesList.Items.Add(testCase.i + " " + testCase.tc.Name, (int) testCase.tc.LastResult).Tag = testCase.tc;
			if (selected >= 0)
			{
				testCasesList.SelectedIndices.Clear();
				testCasesList.SelectedIndices.Add(selected);
			}
		}


		private async Task RunTestCase(ListViewItem selectedItem)
		{
			var testCase = (TestCase) selectedItem.Tag;
			UpdateTestStatus(selectedItem, TestResult.Unknown);
			await testCase.Run();
			Visualize(testCase);
			UpdateTestStatus(selectedItem, testCase.LastResult);
		}

		private void Visualize(TestCase testCase)
		{
			ClearTestCaseView();
			using (Graphics g = Graphics.FromImage(bitmap))
			{
				Brush brush = testCase.LastResult == TestResult.OK ? Brushes.Aquamarine : (testCase.LastResult == TestResult.Failed ? Brushes.LightPink : Brushes.LightGoldenrodYellow);
				g.FillRectangle(brush, 0, 0, bitmap.Width, bitmap.Height);
			}
			using (var ui = new TestCaseUI(bitmap, logTextBox))
				testCase.Visualize(ui);
			pictureContainer.Invalidate();
		}

		private void UpdateTestStatus(ListViewItem selectedItem, TestResult result)
		{
			selectedItem.ImageIndex = (int) result;
		}

		private void ClearTestCaseView()
		{
			logTextBox.Text = "";
			Size size = pictureContainer.ClientSize;
			bitmap = new Bitmap(size.Width, size.Height, PixelFormat.Format32bppArgb);
		}

		private async void testCasesList_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
		{
			ClearTestCaseView();
			if (testCasesList.SelectedItems.Count == 0) return;
			await RunTestCase(testCasesList.SelectedItems[0]);
		}

		private void Repaint()
		{
			ClearTestCaseView();
			List<ListViewItem> tests = testCasesList.SelectedItems.Cast<ListViewItem>().ToList();
			if (tests.Any())
			{
				var testCase = (TestCase) tests.First().Tag;
				Visualize(testCase);
			}
		}

		private void pictureContainer_Paint(object sender, PaintEventArgs e)
		{
			if (bitmap != null)
				e.Graphics.DrawImage(bitmap, 0, 0);
		}

		private void pictureContainer_Resize(object sender, EventArgs e)
		{
			Repaint();
		}

		private async void testCasesList_MouseClick(object sender, MouseEventArgs e)
		{
			if (testCasesList.SelectedItems.Count == 0) return;
			await RunTestCase(testCasesList.SelectedItems[0]);
		}

		private void TestRoom_Shown(object sender, EventArgs e)
		{
			RunAllTests();
		}
	}

	public class FunnyTestcase : TestCase
	{
		public FunnyTestcase(string name) : base(name)
		{
		}

		protected override bool InternalRun()
		{
			Thread.Sleep(1000);
			return new Random().Next(2) == 0;
		}

		protected override void InternalVisualize(TestCaseUI ui)
		{
			ui.Circle(0, 0, 10, Pens.Red);
		}
	}
}