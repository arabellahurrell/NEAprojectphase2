using System;
using System.Runtime.Serialization;
//using System.Runtime.Serialization.DataMemberAttribute;


namespace NEAproject.Models
{
    [DataContract]
    public class datapoint
    {
        [DataMember(Name = "label")]
        public string label ;
        [DataMember(Name = "y")]
        public double y;

        public datapoint(string inputlabel, double inputy)
        {
            label = inputlabel;
            y = inputy;

        }
    }
}