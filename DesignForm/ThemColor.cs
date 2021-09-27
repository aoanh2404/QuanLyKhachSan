using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignForm
{
	public static class ThemColor
	{
		public static Color PrimaryColor { get; set; }
		public static Color SecondaryColor { get; set; }

		public static List<string> ColorList = new List<string>() { "#3F5185",
																	"#009688",
																	"#FF5722",
																	"#607088",
																	"#FF9800",
																	"#9C2780",
																	"#2196F3",
																	"#EA676C",
																	"#E41A4A",
																	"#597888",
																	"#018790",
																	"#0E3441",
																	"#721047",
																	"#EA4833",
																	"#EF937E",
																	"#F37521",
																	"#A12059",
																	"#126881",
																	"#88C248",
																	"#364058",
																	"#00948C",
																	"#E41268",
																	"#49876E",
																	"#7BCFE9",
																	"#871C46" };
		public static Color ChangeColorBrightness(Color color, double correctionFactor)
		{
			double red = color.R;
			double green = color.G;
			double blue = color.B;

			if (correctionFactor < 0)
			{
				correctionFactor = 1 + correctionFactor;
				red *= correctionFactor;
				green *= correctionFactor;
				blue *= correctionFactor;
			}
			else
			{
				red = (255 - red) * correctionFactor + red;
				green = (255 - green) * correctionFactor + green;
				blue = (255 - blue) * correctionFactor + blue;
			}

			return Color.FromArgb(color.A, (byte)red, (byte)green, (byte)blue);
		}

	}
}
