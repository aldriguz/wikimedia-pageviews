using System.Runtime.Serialization;
using System.ComponentModel;

namespace WikimediaData.Entities.Enums
{
    [DataContract]
    public enum EnumDomain
    {
        [EnumMember(Value = "")]
        [Description()]
        wiki,
        
        [EnumMember(Value = "b")]
        wikibooks,
        
        [EnumMember(Value = "d")]
        wiktionary,
        
        [EnumMember(Value = "m")]
        wikimedia,
        
        [EnumMember(Value = "f")]
        foundationwiki,
        
        [EnumMember(Value = "mw")]
        whitelistedproject,
        
        [EnumMember(Value = "n")]
        wikinews,
        
        [EnumMember(Value = "q")]
        wikiquote,
        
        [EnumMember(Value = "s")]
        wikisource,
        
        [EnumMember(Value = "v")]
        wikiversity,
        
        [EnumMember(Value = "voy")]
        wikivoyage,
        
        [EnumMember(Value = "w")]
        mediawikiwiki,
        
        [EnumMember(Value = "wd")]
        wikidatawiki
    }
}
