using HtmlTags;

namespace HeroicCRM.Web.Helpers
{
	public class UIRatingTag : HtmlTag
	{
		public UIRatingTag(string model) : base("rating")
		{
			Attr("ng-model", model);
		}

		public UIRatingTag Max(int max)
		{
			Attr("max", max);

			return this;
		}

		public UIRatingTag NgClick(string action)
		{
			Attr("ng-click", action);

			return this;
		}
	}
}