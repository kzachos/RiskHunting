//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.42
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Xml.Serialization;
using System.Collections;
using System.Collections.Generic;

namespace XmlProc
{
    /// <summary>
    /// ResponseDetailed class to include custom metadata attributes in a 
    /// class so that it can be serialized/deserialized to/from XML.
    /// 
    /// References: 
    /// XML Serialization at http://samples.gotdotnet.com/:
    /// http://samples.gotdotnet.com/QuickStart/howto/default.aspx?url=/quickstart/howto/doc/xmlserialization/rwobjfromxml.aspx
    /// 
    /// How do I serialize an image file as XML in .NET?
    /// http://www.perfectxml.com/Answers.asp?ID=2
    /// </summary>
    
    public class ResponseDetailedSerialized
    {

        public ResponseDetailedSerialized()
        {
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://tempuri.org/ResponseDetailed.xsd", IsNullable = false)]
        public partial class AntiqueResponse
        {

            private MatchedSources matchedSourcesField;

            /// <remarks/>
            public MatchedSources MatchedSources
            {
                get
                {
                    return this.matchedSourcesField;
                }
                set
                {
                    this.matchedSourcesField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://tempuri.org/ResponseDetailed.xsd", IsNullable = false)]
        public partial class MatchedSources
        {

            private List<MatchedSource> matchedSourceField;

            private string countField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("MatchedSource")]
            public List<MatchedSource> MatchedSource
            {
                get
                {
                    return this.matchedSourceField;
                }
                set
                {
                    this.matchedSourceField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute(DataType = "integer")]
            public string Count
            {
                get
                {
                    return this.countField;
                }
                set
                {
                    this.countField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://tempuri.org/ResponseDetailed.xsd", IsNullable = false)]
        public partial class MatchedSource
        {

            private SourceDescription sourceDescriptionField;

            private DataSourceType sourceTypeField;

            private float overallMatchValueField;

            private string sourceIdField;

            private string sourceNameField;

            /// <remarks/>
            public SourceDescription SourceDescription
            {
                get
                {
                    return this.sourceDescriptionField;
                }
                set
                {
                    this.sourceDescriptionField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public DataSourceType SourceType
            {
                get
                {
                    return this.sourceTypeField;
                }
                set
                {
                    this.sourceTypeField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public float OverallMatchValue
            {
                get
                {
                    return this.overallMatchValueField;
                }
                set
                {
                    this.overallMatchValueField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NMTOKEN")]
            public string SourceId
            {
                get
                {
                    return this.sourceIdField;
                }
                set
                {
                    this.sourceIdField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string SourceName
            {
                get
                {
                    return this.sourceNameField;
                }
                set
                {
                    this.sourceNameField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/ResponseDetailed.xsd")]
        public enum DataSourceType
        {

            /// <remarks/>
            Service,

            /// <remarks/>
            Web,

            /// <remarks/>
            P2P,
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://tempuri.org/ResponseDetailed.xsd", IsNullable = false)]
        public partial class SourceDescription
        {

            private MatchedPredicates itemsField;

            private string textField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("MatchedPredicates")]
            public MatchedPredicates Items
            {
                get
                {
                    return this.itemsField;
                }
                set
                {
                    this.itemsField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlTextAttribute()]
            public string Text
            {
                get
                {
                    return this.textField;
                }
                set
                {
                    this.textField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://tempuri.org/ResponseDetailed.xsd", IsNullable = false)]
        public partial class MatchedPredicates
        {

            private List<MatchedPredicate> matchedPredicateField;

            private string countField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("MatchedPredicate")]
            public List<MatchedPredicate> MatchedPredicate
            {
                get
                {
                    return this.matchedPredicateField;
                }
                set
                {
                    this.matchedPredicateField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute(DataType = "integer")]
            public string Count
            {
                get
                {
                    return this.countField;
                }
                set
                {
                    this.countField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://tempuri.org/ResponseDetailed.xsd", IsNullable = false)]
        public partial class MatchedPredicate
        {

            private List<TargetItem> targetItemField;

            private string targetTextCoveredField;

            private string sourceTextCoveredField;

            private float matchValueField;

            private string idField;

            private SimilarityType matchTypeField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("TargetItem")]
            public List<TargetItem> TargetItem
            {
                get
                {
                    return this.targetItemField;
                }
                set
                {
                    this.targetItemField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("TargetTextCovered")]
            public string TargetTextCovered
            {
                get
                {
                    return this.targetTextCoveredField;
                }
                set
                {
                    this.targetTextCoveredField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("SourceTextCovered")]
            public string SourceTextCovered
            {
                get
                {
                    return this.sourceTextCoveredField;
                }
                set
                {
                    this.sourceTextCoveredField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public float MatchValue
            {
                get
                {
                    return this.matchValueField;
                }
                set
                {
                    this.matchValueField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute(DataType = "NMTOKEN")]
            public string Id
            {
                get
                {
                    return this.idField;
                }
                set
                {
                    this.idField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public SimilarityType MatchType
            {
                get
                {
                    return this.matchTypeField;
                }
                set
                {
                    this.matchTypeField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/ResponseDetailed.xsd")]
        public enum SimilarityType
        {

            /// <remarks/>
            LiteralSimilarity,

            /// <remarks/>
            Analogy,

            /// <remarks/>
            MereAppearance,
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://tempuri.org/ResponseDetailed.xsd", IsNullable = false)]
        public partial class TargetItem
        {

            private SourceItem sourceItemField;

            private string termField;

            private TargetItemMatchProperty matchPropertyField;

            private string descriptionField;

            /// <remarks/>
            public SourceItem SourceItem
            {
                get
                {
                    return this.sourceItemField;
                }
                set
                {
                    this.sourceItemField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string Term
            {
                get
                {
                    return this.termField;
                }
                set
                {
                    this.termField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public TargetItemMatchProperty MatchProperty
            {
                get
                {
                    return this.matchPropertyField;
                }
                set
                {
                    this.matchPropertyField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string Description
            {
                get
                {
                    return this.descriptionField;
                }
                set
                {
                    this.descriptionField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public enum TargetItemMatchProperty
        {

            /// <remarks/>
            PredicateValue,

            /// <remarks/>
            Object1,

            /// <remarks/>
            Object2,
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://tempuri.org/ResponseDetailed.xsd", IsNullable = false)]
        public partial class SourceItem
        {

            private float matchValueField;

            private string textField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public float MatchValue
            {
                get
                {
                    return this.matchValueField;
                }
                set
                {
                    this.matchValueField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlTextAttribute()]
            public string Text
            {
                get
                {
                    return this.textField;
                }
                set
                {
                    this.textField = value;
                }
            }
        }
    }
}
