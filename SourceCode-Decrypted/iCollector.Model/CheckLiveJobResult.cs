using System.Linq;
using System.Reflection;
using System.Text;

namespace iCollector.Model;

internal class CheckLiveJobResult
{
	public bool Live { get; set; }

	public string Dtsg { get; set; }

	public override string ToString()
	{
		return GetType().Name + ": " + (from info in GetType().GetProperties()
			select (info.Name, info.GetValue(this, null) ?? "(null)")).Aggregate<(string, object), StringBuilder, string>(new StringBuilder(), delegate(StringBuilder sb, (string Name, object Value) pair)
		{
			StringBuilder stringBuilder;
			if (3u != 0 && 4u != 0)
			{
				stringBuilder = sb;
			}
			StringBuilder.AppendInterpolatedStringHandler handler = default(StringBuilder.AppendInterpolatedStringHandler);
			if (8u != 0 && 0 == 0)
			{
				handler = new StringBuilder.AppendInterpolatedStringHandler(5, 2, stringBuilder);
			}
			var (value, _) = pair;
			if (4u != 0 && 0 == 0)
			{
				handler.AppendFormatted(value);
			}
			if (0 == 0 && 0 == 0)
			{
				handler.AppendLiteral(": ");
			}
			object item = pair.Value;
			if (0 == 0 && 5u != 0)
			{
				handler.AppendFormatted<object>(item);
			}
			if (5u != 0 && uint.MaxValue != 0)
			{
				handler.AppendLiteral(" | ");
			}
			return stringBuilder.Append(ref handler);
		}, (StringBuilder sb) => sb.ToString());
	}
}
