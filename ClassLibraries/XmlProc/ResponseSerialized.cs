//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3615
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by xsd, Version=2.0.50727.1432.
// 

using System.Xml.Serialization;
using System.Collections;
using System.Collections.Generic;

namespace XmlProc 
{

    /// <summary>
    /// 
    /// </summary>
    public class ResponseSerialized
    {
        /// <summary>
        /// 
        /// </summary>
        public ResponseSerialized()
        {
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.1432")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
//        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://achernar.soi.city.ac.uk/xmlSchemas/Response")]
//        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://achernar.soi.city.ac.uk/xmlSchemas/Response", IsNullable = false)]
        public partial class MatchedSources
        {

            private List<MatchedSourcesMatchedSource> matchedSourceField;

            private string responseIdField;

            private string similarityTypeField;

            private string dataSourceTypeField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("MatchedSource")]
            public List<MatchedSourcesMatchedSource> MatchedSource
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
            public string responseId
            {
                get
                {
                    return this.responseIdField;
                }
                set
                {
                    this.responseIdField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute(DataType = "integer")]
            public string similarityType
            {
                get
                {
                    return this.similarityTypeField;
                }
                set
                {
                    this.similarityTypeField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute(DataType = "integer")]
            public string dataSourceType
            {
                get
                {
                    return this.dataSourceTypeField;
                }
                set
                {
                    this.dataSourceTypeField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.1432")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://achernar.soi.city.ac.uk/xmlSchemas/Response")]
        public partial class MatchedSourcesMatchedSource
        {

            private string sourceIdField;

            private string sourceNameField;

            private string contentField;

			private string overallMatchValueField;

            /// <remarks/>
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

            /// <remarks/>
            public string Content
            {
                get
                {
                    return this.contentField;
                }
                set
                {
                    this.contentField = value;
                }
            }

            /// <remarks/>
			public string OverallMatchValue
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
        }
    }
}
