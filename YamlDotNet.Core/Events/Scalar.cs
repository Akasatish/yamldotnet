using System;

namespace YamlDotNet.Core.Events
{
	/// <summary>
	/// Represents a scalar event.
	/// </summary>
	public class Scalar : NodeEvent
	{
		/// <summary>
		/// Gets the event type, which allows for simpler type comparisons.
		/// </summary>
		internal override EventType Type {
			get {
				return EventType.YAML_SCALAR_EVENT;
			}
		}

		private readonly string value;

		/// <summary>
		/// Gets the value.
		/// </summary>
		/// <value>The value.</value>
		public string Value
		{
			get
			{
				return value;
			}
		}

		private readonly ScalarStyle style;

		/// <summary>
		/// Gets the style of the scalar.
		/// </summary>
		/// <value>The style.</value>
		public ScalarStyle Style
		{
			get
			{
				return style;
			}
		}

		private readonly bool isPlainImplicit;

		/// <summary>
		/// Gets a value indicating whether the tag is optional for the plain style.
		/// </summary>
		public bool IsPlainImplicit
		{
			get
			{
				return isPlainImplicit;
			}
		}

		private readonly bool isQuotedImplicit;

		/// <summary>
		/// Gets a value indicating whether the tag is optional for any non-plain style.
		/// </summary>
		public bool IsQuotedImplicit
		{
			get
			{
				return isQuotedImplicit;
			}
		}
		
		internal override bool IsCanonical {
			get {
				return !isPlainImplicit && !isQuotedImplicit;
			}
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Scalar"/> class.
		/// </summary>
		/// <param name="anchor">The anchor.</param>
		/// <param name="tag">The tag.</param>
		/// <param name="value">The value.</param>
		/// <param name="style">The style.</param>
		/// <param name="isPlainImplicit">.</param>
		/// <param name="isQuotedImplicit">.</param>
		/// <param name="start">The start position of the event.</param>
		/// <param name="end">The end position of the event.</param>
		public Scalar(string anchor, string tag, string value, ScalarStyle style, bool isPlainImplicit, bool isQuotedImplicit, Mark start, Mark end)
			: base(anchor, tag, start, end)
		{
			this.value = value;
			this.style = style;
			this.isPlainImplicit = isPlainImplicit;
			this.isQuotedImplicit = isQuotedImplicit;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Scalar"/> class.
		/// </summary>
		/// <param name="anchor">The anchor.</param>
		/// <param name="tag">The tag.</param>
		/// <param name="value">The value.</param>
		/// <param name="style">The style.</param>
		/// <param name="isPlainImplicit">.</param>
		/// <param name="isQuotedImplicit">.</param>
		public Scalar(string anchor, string tag, string value, ScalarStyle style, bool isPlainImplicit, bool isQuotedImplicit)
			: this(anchor, tag, value, style, isPlainImplicit, isQuotedImplicit, Mark.Empty, Mark.Empty)
		{
		}
	}
}
