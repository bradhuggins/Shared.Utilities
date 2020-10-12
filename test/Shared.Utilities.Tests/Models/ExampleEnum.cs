#region Using Statements
using System;
using System.Runtime.Serialization;
#endregion

namespace Shared.Utilities.Tests.Models
{    
	[DataContract]
    public enum ExampleEnum : int
    {
        [EnumMember(Value = "Unknown")]
        Unknown = 0,
        [EnumMember(Value = "Value 1")]
        Value1 = 1,
        [EnumMember(Value = "Value 2")]
        Value2 = 2
    }




}
