using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Bson.Serialization.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yekzen.Data.Mongo
{
    /// <summary>
    /// A convention that allows you to set the string serialization representation.
    /// </summary>
    public class StringIdRepresentationConvention : ConventionBase, IMemberMapConvention
    {
        // private fields
        private readonly BsonType _representation;

        // constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="DecimalRepresentationConvention" /> class.
        /// </summary>
        /// <param name="representation">The serialization representation.</param>
        public StringIdRepresentationConvention(BsonType representation)
        {
            _representation = representation;
        }

        /// <summary>
        /// Changes the decimal representation if the member is a decimal
        /// </summary>
        /// <param name="memberMap"></param>
        public void Apply(BsonMemberMap memberMap)
        {
            if (memberMap.MemberType == typeof(string) && memberMap.ClassMap.IdMemberMap == memberMap)
            {
                memberMap.SetSerializer(new StringSerializer(BsonType.ObjectId));
            }
        }
    }
    
}
