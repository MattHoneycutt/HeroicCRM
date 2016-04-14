using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.UI;
using HeroicCRM.Web.Utilities;
using HtmlTags;

namespace HeroicCRM.Web.Helpers
{
	public class GridTag : HtmlTag
	{
		public class ColumnBuilder<T>
		{
			private readonly GridTag _tag;

			public ColumnBuilder(GridTag tag)
			{
				_tag = tag;
			}

			public void Add<TProp>(Expression<Func<T, TProp>> property,
				string columnHeader = null,
				string cellFilter = null)
			{
				_tag._columns.Add(new ColumnDefinition
				{
					Field = property.ToCamelCaseName(),
					Name = columnHeader,
					CellFilter = cellFilter
				});
			}
		}

		private class ColumnDefinition
		{
			public string Field { get; set; }

			public string Name { get; set; }

			public string CellFilter { get; set; }
		}

		private readonly List<ColumnDefinition> _columns = new List<ColumnDefinition>();

		public GridTag(string dataUrl)
			: base("mvc-grid")
		{
			Attr("grid-data-url", dataUrl);
		}

		public new GridTag Title(string title)
		{
			Attr("title", title);

			return this;
		}

		public GridTag Columns<T>(Action<ColumnBuilder<T>> configAction)
		{
			var builder = new ColumnBuilder<T>(this);
			configAction(builder);
			return this;
		}

		protected override void writeHtml(HtmlTextWriter html)
		{
			if (_columns.Any())
				this.Attr("columns", _columns.ToArray().ToJson(includeNull: false));

			base.writeHtml(html);
		}
	}
}