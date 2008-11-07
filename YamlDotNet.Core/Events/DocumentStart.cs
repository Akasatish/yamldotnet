using System;
using System.Globalization;
using YamlDotNet.Core.Tokens;

namespace YamlDotNet.Core.Events
{
	/// <summary>
	/// Represents a document start event.
	/// </summary>
	public class DocumentStart : ParsingEvent, IDocumentStart
	{
		/// <summary>
		/// Gets the event type, which allows for simpler type comparisons.
		/// </summary>
		internal override EventType Type {
			get {
				return EventType.YAML_DOCUMENT_START_EVENT;
			}
		}
		
		private readonly TagDirectiveCollection tags;
		private readonly VersionDirective version;

		/// <summary>
		/// Gets the tags.
		/// </summary>
		/// <value>The tags.</value>
		public TagDirectiveCollection Tags
		{
			get
			{
				return tags;
			}
		}

		/// <summary>
		/// Gets the version.
		/// </summary>
		/// <value>The version.</value>
		public VersionDirective Version
		{
			get
			{
				return version;
			}
		}

		private readonly bool isImplicit;

		/// <summary>
		/// Gets a value indicating whether this instance is implicit.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if this instance is implicit; otherwise, <c>false</c>.
		/// </value>
		public bool IsImplicit
		{
			get
			{
				return isImplicit;
			}
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="DocumentStart"/> class.
		/// </summary>
		/// <param name="version">The version.</param>
		/// <param name="tags">The tags.</param>
		/// <param name="isImplicit">Indicates whether the event is implicit.</param>
		/// <param name="start">The start position of the event.</param>
		/// <param name="end">The end position of the event.</param>
		public DocumentStart(VersionDirective version, TagDirectiveCollection tags, bool isImplicit, Mark start, Mark end)
			: base(start, end)
		{
			this.version = version;
			this.tags = tags;
			this.isImplicit = isImplicit;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="DocumentStart"/> class.
		/// </summary>
		/// <param name="version">The version.</param>
		/// <param name="tags">The tags.</param>
		/// <param name="isImplicit">Indicates whether the event is implicit.</param>
		public DocumentStart(VersionDirective version, TagDirectiveCollection tags, bool isImplicit)
			: this(version, tags, isImplicit, Mark.Empty, Mark.Empty)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="DocumentStart"/> class.
		/// </summary>
		/// <param name="start">The start position of the event.</param>
		/// <param name="end">The end position of the event.</param>
		public DocumentStart(Mark start, Mark end)
			: this(null, null, true, start, end)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="DocumentStart"/> class.
		/// </summary>
		public DocumentStart()
			: this(null, null, true, Mark.Empty, Mark.Empty)
		{
		}

		/// <summary>
		/// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
		/// </summary>
		/// <returns>
		/// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
		/// </returns>
		public override string ToString()
		{
			return string.Format(
				CultureInfo.InvariantCulture,
				"Document start [isImplicit = {0}]",
				isImplicit
			);
		}
	}
}