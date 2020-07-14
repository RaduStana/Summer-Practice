using System;
using System.Xml.Serialization;
using System.Collections.Generic;
namespace Convertor.Model
{
		[XmlRoot(ElementName = "Excelversion")]
		public class Excelversion
		{
			[XmlAttribute(AttributeName = "Value")]
			public string Value { get; set; }
		}

		[XmlRoot(ElementName = "Tester")]
		public class Tester
		{
			[XmlAttribute(AttributeName = "Value")]
			public string Value { get; set; }
		}

		[XmlRoot(ElementName = "Email")]
		public class Email
		{
			[XmlAttribute(AttributeName = "Value")]
			public string Value { get; set; }
			[XmlAttribute(AttributeName = "EnableEmail")]
			public string EnableEmail { get; set; }
			[XmlAttribute(AttributeName = "EnableCC")]
			public string EnableCC { get; set; }
			[XmlAttribute(AttributeName = "CC")]
			public string CC { get; set; }
		}

		[XmlRoot(ElementName = "Software")]
		public class Software
		{
			[XmlAttribute(AttributeName = "Value")]
			public string Value { get; set; }
			[XmlAttribute(AttributeName = "Addition")]
			public string Addition { get; set; }
			[XmlAttribute(AttributeName = "SoftwarePath")]
			public string SoftwarePath { get; set; }
		}

		[XmlRoot(ElementName = "Subsystem")]
		public class Subsystem
		{
			[XmlAttribute(AttributeName = "Value")]
			public string Value { get; set; }
		}

		[XmlRoot(ElementName = "TestGroupId")]
		public class TestGroupId
		{
			[XmlAttribute(AttributeName = "Value")]
			public string Value { get; set; }
		}

		[XmlRoot(ElementName = "Testmode")]
		public class Testmode
		{
			[XmlAttribute(AttributeName = "Value")]
			public string Value { get; set; }
		}

		[XmlRoot(ElementName = "CCP")]
		public class CCP
		{
			[XmlAttribute(AttributeName = "Value")]
			public string Value { get; set; }
		}

		[XmlRoot(ElementName = "BaselineText")]
		public class BaselineText
		{
			[XmlAttribute(AttributeName = "Value")]
			public string Value { get; set; }
		}

		[XmlRoot(ElementName = "BaselineLink")]
		public class BaselineLink
		{
			[XmlAttribute(AttributeName = "Value")]
			public string Value { get; set; }
		}

		[XmlRoot(ElementName = "Reanalyse")]
		public class Reanalyse
		{
			[XmlAttribute(AttributeName = "Value")]
			public string Value { get; set; }
		}

		[XmlRoot(ElementName = "Testsetcomment")]
		public class Testsetcomment
		{
			[XmlAttribute(AttributeName = "Category")]
			public string Category { get; set; }
		}

		[XmlRoot(ElementName = "Code")]
		public class Code
		{
			[XmlAttribute(AttributeName = "Value")]
			public string Value { get; set; }
		}

		[XmlRoot(ElementName = "Information")]
		public class Information
		{
			[XmlElement(ElementName = "Excelversion")]
			public Excelversion Excelversion { get; set; }
			[XmlElement(ElementName = "Tester")]
			public Tester Tester { get; set; }
			[XmlElement(ElementName = "Email")]
			public Email Email { get; set; }
			[XmlElement(ElementName = "Software")]
			public Software Software { get; set; }
			[XmlElement(ElementName = "Subsystem")]
			public Subsystem Subsystem { get; set; }
			[XmlElement(ElementName = "TestGroupId")]
			public TestGroupId TestGroupId { get; set; }
			[XmlElement(ElementName = "Testmode")]
			public Testmode Testmode { get; set; }
			[XmlElement(ElementName = "CCP")]
			public CCP CCP { get; set; }
			[XmlElement(ElementName = "BaselineText")]
			public BaselineText BaselineText { get; set; }
			[XmlElement(ElementName = "BaselineLink")]
			public BaselineLink BaselineLink { get; set; }
			[XmlElement(ElementName = "Reanalyse")]
			public Reanalyse Reanalyse { get; set; }
			[XmlElement(ElementName = "Testsetcomment")]
			public Testsetcomment Testsetcomment { get; set; }
			[XmlElement(ElementName = "Code")]
			public Code Code { get; set; }
		}

		[XmlRoot(ElementName = "Entry")]
		public class Entry
		{
			[XmlAttribute(AttributeName = "Id")]
			public string Id { get; set; }
			[XmlAttribute(AttributeName = "Enabled")]
			public string Enabled { get; set; }
			[XmlAttribute(AttributeName = "Name")]
			public string Name { get; set; }
			[XmlAttribute(AttributeName = "Description")]
			public string Description { get; set; }
			[XmlAttribute(AttributeName = "Length")]
			public string Length { get; set; }
			[XmlAttribute(AttributeName = "Temp")]
			public string Temp { get; set; }
			[XmlAttribute(AttributeName = "Actuation")]
			public string Actuation { get; set; }
			[XmlAttribute(AttributeName = "Definition")]
			public string Definition { get; set; }
			[XmlAttribute(AttributeName = "Color")]
			public string Color { get; set; }
			[XmlAttribute(AttributeName = "Bold")]
			public string Bold { get; set; }
			[XmlElement(ElementName = "Requirements")]
			public Requirements Requirements { get; set; }
			[XmlElement(ElementName = "Condition")]
			public List<Condition> Condition { get; set; }
			[XmlAttribute(AttributeName = "Test")]
			public string Test { get; set; }
			[XmlAttribute(AttributeName = "Function")]
			public string Function { get; set; }
			[XmlAttribute(AttributeName = "Code")]
			public string Code { get; set; }
		}

		[XmlRoot(ElementName = "Tests")]
		public class Tests
		{
			[XmlElement(ElementName = "Entry")]
			public List<Entry> Entry { get; set; }
		}

		[XmlRoot(ElementName = "Requirements")]
		public class Requirements
		{
			[XmlAttribute(AttributeName = "ID")]
			public string ID { get; set; }
			[XmlAttribute(AttributeName = "Initiator")]
			public string Initiator { get; set; }
			[XmlAttribute(AttributeName = "Date")]
			public string Date { get; set; }
			[XmlAttribute(AttributeName = "ShortDescription")]
			public string ShortDescription { get; set; }
			[XmlAttribute(AttributeName = "Type")]
			public string Type { get; set; }
			[XmlAttribute(AttributeName = "Importance")]
			public string Importance { get; set; }
			[XmlAttribute(AttributeName = "Description")]
			public string Description { get; set; }
			[XmlAttribute(AttributeName = "Rationale")]
			public string Rationale { get; set; }
			[XmlAttribute(AttributeName = "UseCase")]
			public string UseCase { get; set; }
			[XmlAttribute(AttributeName = "Dependencies")]
			public string Dependencies { get; set; }
			[XmlAttribute(AttributeName = "Conflicts")]
			public string Conflicts { get; set; }
			[XmlAttribute(AttributeName = "SupportingMaterial")]
			public string SupportingMaterial { get; set; }
		}

		[XmlRoot(ElementName = "Functions")]
		public class Functions
		{
			[XmlElement(ElementName = "Entry")]
			public List<Entry> Entry { get; set; }
		}

		[XmlRoot(ElementName = "Condition")]
		public class Condition
		{
			[XmlAttribute(AttributeName = "Type")]
			public string Type { get; set; }
			[XmlAttribute(AttributeName = "Value")]
			public string Value { get; set; }
			[XmlAttribute(AttributeName = "Bit0")]
			public string Bit0 { get; set; }
			[XmlAttribute(AttributeName = "Bit1")]
			public string Bit1 { get; set; }
			[XmlAttribute(AttributeName = "Bit2")]
			public string Bit2 { get; set; }
			[XmlAttribute(AttributeName = "Bit3")]
			public string Bit3 { get; set; }
			[XmlAttribute(AttributeName = "Bit4")]
			public string Bit4 { get; set; }
			[XmlAttribute(AttributeName = "Bit5")]
			public string Bit5 { get; set; }
			[XmlAttribute(AttributeName = "Bit6")]
			public string Bit6 { get; set; }
			[XmlAttribute(AttributeName = "Bit7")]
			public string Bit7 { get; set; }
		}

		[XmlRoot(ElementName = "Dataset")]
		public class Dataset
		{
			[XmlElement(ElementName = "Entry")]
			public List<Entry> Entry { get; set; }
		}

		[XmlRoot(ElementName = "Hash")]
		public class Hash
		{
			[XmlElement(ElementName = "Entry")]
			public List<Entry> Entry { get; set; }
		}

		[XmlRoot(ElementName = "Testsetfile")]
		public class Testsetfile
		{
			[XmlElement(ElementName = "Information")]
			public Information Information { get; set; }
			[XmlElement(ElementName = "Tests")]
			public Tests Tests { get; set; }
			[XmlElement(ElementName = "Functions")]
			public Functions Functions { get; set; }
			[XmlElement(ElementName = "TestSetConfig")]
			public string TestSetConfig { get; set; }
			[XmlElement(ElementName = "Dataset")]
			public Dataset Dataset { get; set; }
			[XmlElement(ElementName = "MatLabScripts")]
			public string MatLabScripts { get; set; }
			[XmlElement(ElementName = "TestCaseSpecifications")]
			public string TestCaseSpecifications { get; set; }
			[XmlElement(ElementName = "Triggers")]
			public string Triggers { get; set; }
			[XmlElement(ElementName = "Hash")]
			public Hash Hash { get; set; }
			[XmlElement(ElementName = "AliasNames")]
			public string AliasNames { get; set; }
			[XmlElement(ElementName = "IBobSignals")]
			public string IBobSignals { get; set; }
			[XmlAttribute(AttributeName = "prename")]
			public string Prename { get; set; }
		}
}
