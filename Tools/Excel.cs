using OfficeOpenXml;
using OfficeOpenXml.Drawing;
using OfficeOpenXml.Drawing.Chart;
using OfficeOpenXml.Style;
using System.ComponentModel;
using System.Drawing;

namespace Tools
{
    public class Excel
    {
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (_worksheet != null)
                _worksheet.Dispose();
            if (_workbook != null)
                _workbook.Dispose();
            if (_file != null)
                _file.Dispose();
        }
        readonly MemoryStream _file;
        readonly ExcelPackage _package;
        readonly ExcelWorkbook _workbook;
        ExcelWorksheet? _worksheet;
        readonly string defaultFont = "Oriflame Sans Print";
        public Excel()
        {
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            _file = new MemoryStream();
            _package = new ExcelPackage(_file);
            _workbook = _package.Workbook;

        }

        public void AddPage(string name)
        {
            if (_workbook != null)
                _worksheet = _workbook.Worksheets.Add(name);
        }
        public void writeOnCell(int row, int col, object value, bool bold = false, int fontSize = 12, FormatType? format = FormatType.String, Align? align = Align.Left, Color? fontColor = null, Color? fillColor = null)
        {
            if (_worksheet != null)
            {
                _worksheet.Cells[row, col].Value = value;
                _worksheet.Cells[row, col].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                _worksheet.Cells[row, col].Style.Font.Bold = bold;
                _worksheet.Cells[row, col].Style.Font.Name = defaultFont;
                _worksheet.Cells[row, col].Style.Font.Size = fontSize;
                _worksheet.Cells[row, col].Style.WrapText = true;
                switch (format)
                {
                    case FormatType.String:
                        break;
                    case FormatType.Int:
                        _worksheet.Cells[row, col].Style.Numberformat.Format = "#,##0";
                        break;
                    case FormatType.Decimal:
                        _worksheet.Cells[row, col].Style.Numberformat.Format = "#,##0.00";
                        break;
                    case FormatType.Date:
                        _worksheet.Cells[row, col].Style.Numberformat.Format = "dd/mm/yyyy;@";
                        break;
                    case FormatType.DateTime:
                        _worksheet.Cells[row, col].Style.Numberformat.Format = "[$-en-US]dd/mm/yyyy h:mm AM/PM;@";
                        break;
                }
                switch (align)
                {
                    case Align.Left:
                        _worksheet.Cells[row, col].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                        break;
                    case Align.Right:
                        _worksheet.Cells[row, col].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        break;
                    case Align.Center:
                        _worksheet.Cells[row, col].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        break;
                }
                if (fontColor != null)
                {
                    _worksheet.Cells[row, col].Style.Font.Color.SetColor(fontColor.Value);
                }
                if (fillColor != null)
                {
                    _worksheet.Cells[row, col].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    _worksheet.Cells[row, col].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    _worksheet.Cells[row, col].Style.Fill.PatternColor.SetColor(Color.Transparent);
                    _worksheet.Cells[row, col].Style.Fill.BackgroundColor.SetColor(fillColor.Value);
                }
            }
        }
        public void shrinkToFit(bool shrinkToFit, int fromRow, int fromCol, int? toRow = null, int? toCol = null)
        {
            if (_worksheet != null)
            {
                ExcelAddress _address = new ExcelAddress(fromRow, fromCol, (toRow ?? fromRow), (toCol ?? fromCol));
                _worksheet.Select(_address);
                ExcelRange _range = _worksheet.SelectedRange;
                _range.Style.ShrinkToFit = shrinkToFit;
            }
        }
        public void shrinkToFit(bool shrinkToFit, string address)
        {
            if (_worksheet != null)
            {
                ExcelAddress _address = new ExcelAddress(address);
                _worksheet.Select(_address);
                ExcelRange _range = _worksheet.SelectedRange;
                _range.Style.ShrinkToFit = shrinkToFit;
            }
        }
        public void wrapText(bool wrapText, int fromRow, int fromCol, int? toRow = null, int? toCol = null)
        {
            if (_worksheet != null)
            {
                ExcelAddress _address = new ExcelAddress(fromRow, fromCol, (toRow ?? fromRow), (toCol ?? fromCol));
                _worksheet.Select(_address);
                ExcelRange _range = _worksheet.SelectedRange;
                _range.Style.WrapText = wrapText;
            }
        }
        public void wrapText(bool wrapText, string address)
        {
            if (_worksheet != null)
            {
                ExcelAddress _address = new ExcelAddress(address);
                _worksheet.Select(_address);
                ExcelRange _range = _worksheet.SelectedRange;
                _range.Style.WrapText = wrapText;
            }
        }
        public void fillBackgroundColor(Color color, int fromRow, int fromCol, int? toRow = null, int? toCol = null)
        {
            if (_worksheet != null)
            {
                ExcelAddress _address = new ExcelAddress(fromRow, fromCol, (toRow ?? fromRow), (toCol ?? fromCol));
                _worksheet.Select(_address);
                ExcelRange _range = _worksheet.SelectedRange;
                _range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                _range.Style.Fill.PatternColor.SetColor(Color.Transparent);
                _range.Style.Fill.BackgroundColor.SetColor(color);
            }
        }
        public void fillBackgroundColor(Color color, string address)
        {
            if (_worksheet != null)
            {
                ExcelAddress _address = new ExcelAddress(address);
                _worksheet.Select(_address);
                ExcelRange _range = _worksheet.SelectedRange;
                _range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                _range.Style.Fill.PatternColor.SetColor(Color.Transparent);
                _range.Style.Fill.BackgroundColor.SetColor(color);
            }
        }
        public void fillBorderCell(int fromRow, int fromCol, bool top = false, bool bottom = false, bool left = false, bool right = false)
        {
            if (_worksheet != null)
            {
                ExcelAddress _address = new ExcelAddress(fromRow, fromCol, fromRow, fromCol);
                _worksheet.Select(_address);
                ExcelRange _range = _worksheet.SelectedRange;
                if (top)
                {
                    _range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    _range.Style.Border.Top.Color.SetColor(Color.Black);
                }
                if (bottom)
                {
                    _range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    _range.Style.Border.Bottom.Color.SetColor(Color.Black);
                }
                if (left)
                {
                    _range.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    _range.Style.Border.Left.Color.SetColor(Color.Black);
                }
                if (right)
                {
                    _range.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    _range.Style.Border.Right.Color.SetColor(Color.Black);
                }
                _worksheet.Cells.AutoFitColumns();
            }
        }
        public void fillBorderCell(int fromRow, int fromCol, int toRow, int toCol, bool top = false, bool bottom = false, bool left = false, bool right = false)
        {
            if (_worksheet != null)
            {
                ExcelAddress _address = new ExcelAddress(fromRow, fromCol, toRow, toCol);
                _worksheet.Select(_address);
                ExcelRange _range = _worksheet.SelectedRange;
                if (top)
                {
                    _range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    _range.Style.Border.Top.Color.SetColor(Color.Black);
                }
                if (bottom)
                {
                    _range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    _range.Style.Border.Bottom.Color.SetColor(Color.Black);
                }
                if (left)
                {
                    _range.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    _range.Style.Border.Left.Color.SetColor(Color.Black);
                }
                if (right)
                {
                    _range.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    _range.Style.Border.Right.Color.SetColor(Color.Black);
                }
                _worksheet.Cells.AutoFitColumns();
            }
        }
        public void fillBorderCell(string address, bool top = false, bool bottom = false, bool left = false, bool right = false)
        {
            if (_worksheet != null)
            {
                ExcelAddress _address = new ExcelAddress(address);
                _worksheet.Select(_address);
                ExcelRange _range = _worksheet.SelectedRange;
                if (top)
                {
                    _range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    _range.Style.Border.Top.Color.SetColor(Color.Black);
                }
                if (bottom)
                {
                    _range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    _range.Style.Border.Bottom.Color.SetColor(Color.Black);
                }
                if (left)
                {
                    _range.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    _range.Style.Border.Left.Color.SetColor(Color.Black);
                }
                if (right)
                {
                    _range.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    _range.Style.Border.Right.Color.SetColor(Color.Black);
                }
                _worksheet.Cells.AutoFitColumns();
            }
        }
        public void mergeCells(int fromRow, int fromCol, int toRow, int toCol)
        {
            if (_worksheet != null)
            {
                ExcelAddress _address = new ExcelAddress(fromRow, fromCol, toRow, toCol);
                _worksheet.Select(_address);
                ExcelRange _range = _worksheet.SelectedRange;
                _range.Merge = true;
            }
        }
        public void mergeCells(string address)
        {
            if (_worksheet != null)
            {
                ExcelAddress _address = new ExcelAddress(address);
                _worksheet.Select(_address);
                ExcelRange _range = _worksheet.SelectedRange;
                _range.Merge = true;
            }
        }
        public void sizeColumn(int col, int size)
        {
            if (_worksheet != null)
                _worksheet.Column(col).Width = size;
        }
        public void columnAutoFit()
        {
            if (_worksheet != null)
                _worksheet.Columns.AutoFit();
        }

        public void showGridLines(bool lines)
        {
            if (_worksheet != null)
                _worksheet.View.ShowGridLines = lines;
        }
        public void hidePage(bool hidden)
        {
            if (_worksheet != null)
                _worksheet.Hidden = hidden ? eWorkSheetHidden.Hidden : eWorkSheetHidden.Visible;
        }
        public void freezePanels(int row, int col)
        {
            if (_worksheet != null)
                _worksheet.View.FreezePanes(row, col);
        }
        private void toTopSheet()
        {
            if (_workbook != null)
            {
                ExcelAddress _address = new ExcelAddress(1, 1, 1, 1);
                foreach (var sheet in _workbook.Worksheets)
                    sheet.Select(_address);
            }
        }
        public byte[] CreateFile()
        {
            toTopSheet();
            _package.Save();
            _file.Seek(0, SeekOrigin.Current);
            return _file.ToArray();
        }
        public string CreateBase64()
        {
            return Convert.ToBase64String(CreateFile());
        }

        public void AddImage(string rute, int row, int col, int width, int height)
        {
            if (_worksheet != null)
            {
                ExcelPicture _picture = _worksheet.Drawings.AddPicture("", rute);
                _picture.SetSize(width, height);
                _picture.From.Column = col;
                _picture.From.ColumnOff = col;
                _picture.From.Row = row;
                _picture.From.RowOff = row;
            }
        }
        public void AddChart(eChartType typeChart = eChartType.Pie, string title = "", eLegendPosition positionTitle = eLegendPosition.Bottom, bool ShowPercent = false, int width = 400, int height = 400, int row = 4, int col = 2, List<ParametersChartSeries>? ChartSeries = null, bool dataTable = false)
        {
            if (_worksheet != null)
            {
                Random rnd = new Random();
                ExcelChart _chart = _worksheet.Drawings.AddChart($"Chart{rnd.Next(1, 100)}", typeChart);

                if (ChartSeries != null)
                    foreach (var _row in ChartSeries)
                    {
                        if (_row.title == "")
                            _chart.Series.Add(_row.values, _row.display);
                        else
                            _chart.Series.Add(_row.values, _row.display).HeaderAddress = _worksheet.Cells[_row.title];
                    }

                _chart.Title.Text = title;
                _chart.Legend.Position = positionTitle;
                _chart.SetSize(width, height);
                _chart.SetPosition(row, 0, col, 0);

                if (typeChart == eChartType.Pie)
                    ((ExcelPieChart)_chart).DataLabel.ShowPercent = ShowPercent;

                if (dataTable)
                    _chart.PlotArea.CreateDataTable();

                if (typeChart == eChartType.ColumnClustered)
                {
                    _chart.XAxis.RemoveGridlines();
                    _chart.YAxis.RemoveGridlines();
                }
            }
        }
    }

    public enum FormatType
    {
        String = 1,
        Int = 2,
        Decimal = 3,
        Date = 4,
        DateTime = 5
    }
    public enum Align
    {
        Left = 1,
        Right = 2,
        Center = 3
    }
    public class ParametersChartSeries
    {
        public string display { get; set; } = string.Empty;
        public string values { get; set; } = string.Empty;
        public string title { get; set; } = string.Empty;
    }
}