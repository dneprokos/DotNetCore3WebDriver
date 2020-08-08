using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using WebDriverWithCore3Tests.Common.WebElements;

namespace WebDriverWithCore3Tests.Common.Components
{
    public class TableComponent<T> where T : new()
    {
        private readonly TableLocators locators;

        public TableComponent()
        {
            locators = new TableLocators();
        }

        public TableComponent(TableLocators locatiors)
        {
            this.locators = locatiors;
        }

        public IList<TableHeaderElement> GetHeaderElements() 
        {
            return locators.TableHeaders;
        }

        public IList<string> GetHeaderNames()
        {
            return GetHeaderElements().Select(el => el.GetText()).ToList();
        }

        public IList<WebElement> GetRows() 
        {
            return locators.BodyRows.ToList();
        }

        public IList<WebElement> GetCells() 
        {
            return locators.Cells.ToList();
        }

        public List<T> GetRowsWithData()
        {
            var headers = GetHeaderNames();
            var rows = GetRows();

            var mappedRowsWitData = new List<T>();

            //ForEach row
            for (int i = 0; i < rows.Count; i++)
            {
                var rowCells = locators.RowCells(rows[i]);
                Dictionary<string, string> rowWithData = new Dictionary<string, string>();

                for (int j = 0; j < rowCells.Count; j++)
                {
                    rowWithData.Add(headers[j], rowCells[j].GetInnerText());
                }
                mappedRowsWitData.Add(GetObject(rowWithData));
            }

            return mappedRowsWitData;
        }




        private static T GetObject(IDictionary<string, string> d)
        {
            PropertyInfo[] props = typeof(T).GetProperties();
            T res = Activator.CreateInstance<T>();
            for (int i = 0; i < props.Length; i++)
            {
                if (props[i].CanWrite && d.ContainsKey(props[i].Name))
                {
                    props[i].SetValue(res, d[props[i].Name], null);
                }
            }
            return res;
        }


    }
}
