/*
 * Mitl-ufer public API
 *
 * This is the public API of Mitl-ufer
 *
 * OpenAPI spec version: 1.0.0
 * Contact: tobrohl@gmail.com
 * Generated by: https://openapi-generator.tech
 */

using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Org.OpenAPITools.Models
{ 
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class User : IEquatable<User>
    { 
        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [Required]
        [DataMember(Name="name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets Laufort
        /// </summary>
        [Required]
        [DataMember(Name="laufort")]
        public string Laufort { get; set; }

        /// <summary>
        /// Gets or Sets EMail
        /// </summary>
        [Required]
        [DataMember(Name="eMail")]
        public string EMail { get; set; }

        /// <summary>
        /// Gets or Sets Geburtsdatum
        /// </summary>
        [Required]
        [DataMember(Name="geburtsdatum")]
        public DateTime? Geburtsdatum { get; set; }

        /// <summary>
        /// Gets or Sets Laufniveau
        /// </summary>
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public enum LaufniveauEnum
        {
            
            /// <summary>
            /// Enum AnfaengerEnum for Anfaenger
            /// </summary>
            [EnumMember(Value = "Anfaenger")]
            AnfaengerEnum = 1,
            
            /// <summary>
            /// Enum FortgeschrittenEnum for Fortgeschritten
            /// </summary>
            [EnumMember(Value = "Fortgeschritten")]
            FortgeschrittenEnum = 2,
            
            /// <summary>
            /// Enum ProfiEnum for Profi
            /// </summary>
            [EnumMember(Value = "Profi")]
            ProfiEnum = 3
        }

        /// <summary>
        /// Gets or Sets Laufniveau
        /// </summary>
        [Required]
        [DataMember(Name="laufniveau")]
        public LaufniveauEnum? Laufniveau { get; set; }

        /// <summary>
        /// Gets or Sets Ziel
        /// </summary>
        [Required]
        [DataMember(Name="ziel")]
        public int? Ziel { get; set; }

        /// <summary>
        /// Gets or Sets Profilbild
        /// </summary>
        [Required]
        [DataMember(Name="profilbild")]
        public string Profilbild { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class User {\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Laufort: ").Append(Laufort).Append("\n");
            sb.Append("  EMail: ").Append(EMail).Append("\n");
            sb.Append("  Geburtsdatum: ").Append(Geburtsdatum).Append("\n");
            sb.Append("  Laufniveau: ").Append(Laufniveau).Append("\n");
            sb.Append("  Ziel: ").Append(Ziel).Append("\n");
            sb.Append("  Profilbild: ").Append(Profilbild).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((User)obj);
        }

        /// <summary>
        /// Returns true if User instances are equal
        /// </summary>
        /// <param name="other">Instance of User to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(User other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    Name == other.Name ||
                    Name != null &&
                    Name.Equals(other.Name)
                ) && 
                (
                    Laufort == other.Laufort ||
                    Laufort != null &&
                    Laufort.Equals(other.Laufort)
                ) && 
                (
                    EMail == other.EMail ||
                    EMail != null &&
                    EMail.Equals(other.EMail)
                ) && 
                (
                    Geburtsdatum == other.Geburtsdatum ||
                    Geburtsdatum != null &&
                    Geburtsdatum.Equals(other.Geburtsdatum)
                ) && 
                (
                    Laufniveau == other.Laufniveau ||
                    Laufniveau != null &&
                    Laufniveau.Equals(other.Laufniveau)
                ) && 
                (
                    Ziel == other.Ziel ||
                    Ziel != null &&
                    Ziel.Equals(other.Ziel)
                ) && 
                (
                    Profilbild == other.Profilbild ||
                    Profilbild != null &&
                    Profilbild.Equals(other.Profilbild)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                var hashCode = 41;
                // Suitable nullity checks etc, of course :)
                    if (Name != null)
                    hashCode = hashCode * 59 + Name.GetHashCode();
                    if (Laufort != null)
                    hashCode = hashCode * 59 + Laufort.GetHashCode();
                    if (EMail != null)
                    hashCode = hashCode * 59 + EMail.GetHashCode();
                    if (Geburtsdatum != null)
                    hashCode = hashCode * 59 + Geburtsdatum.GetHashCode();
                    if (Laufniveau != null)
                    hashCode = hashCode * 59 + Laufniveau.GetHashCode();
                    if (Ziel != null)
                    hashCode = hashCode * 59 + Ziel.GetHashCode();
                    if (Profilbild != null)
                    hashCode = hashCode * 59 + Profilbild.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(User left, User right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(User left, User right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
