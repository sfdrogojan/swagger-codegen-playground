/* 
 * Marketing Cloud REST API
 *
 * Marketing Cloud's REST API is our newest API. It supports multi-channel use cases, is much more lightweight and easy to use than our SOAP API, and is getting more comprehensive with every release.
 *
 * OpenAPI spec version: 1.0.0
 * Contact: mc_sdk@salesforce.com
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using SwaggerDateConverter = Salesforce.MarketingCloud.Client.SwaggerDateConverter;

namespace Salesforce.MarketingCloud.Model
{
    /// <summary>
    /// AssetError
    /// </summary>
    [DataContract]
        public partial class AssetError :  IEquatable<AssetError>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AssetError" /> class.
        /// </summary>
        /// <param name="">The error message.</param>
        /// <param name="">The specific error code.</param>
        /// <param name="">Any specific documentation for the error.</param>
        public AssetError(string  = default(string), BigDecimal  = default(BigDecimal), string  = default(string))
        {
            this.Message = ;
            this.ErrorCode = ;
            this.Documentation = ;
        }
        
        /// <summary>
        /// The error message
        /// </summary>
        /// <value>The error message</value>
        [DataMember(Name="Message", EmitDefaultValue=false)]
        public string Message { get; set; }

        /// <summary>
        /// The specific error code
        /// </summary>
        /// <value>The specific error code</value>
        [DataMember(Name="ErrorCode", EmitDefaultValue=false)]
        public BigDecimal ErrorCode { get; set; }

        /// <summary>
        /// Any specific documentation for the error
        /// </summary>
        /// <value>Any specific documentation for the error</value>
        [DataMember(Name="Documentation", EmitDefaultValue=false)]
        public string Documentation { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class AssetError {\n");
            sb.Append("  Message: ").Append(Message).Append("\n");
            sb.Append("  ErrorCode: ").Append(ErrorCode).Append("\n");
            sb.Append("  Documentation: ").Append(Documentation).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as AssetError);
        }

        /// <summary>
        /// Returns true if AssetError instances are equal
        /// </summary>
        /// <param name="input">Instance of AssetError to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AssetError input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Message == input.Message ||
                    (this.Message != null &&
                    this.Message.Equals(input.Message))
                ) && 
                (
                    this.ErrorCode == input.ErrorCode ||
                    (this.ErrorCode != null &&
                    this.ErrorCode.Equals(input.ErrorCode))
                ) && 
                (
                    this.Documentation == input.Documentation ||
                    (this.Documentation != null &&
                    this.Documentation.Equals(input.Documentation))
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
                int hashCode = 41;
                if (this.Message != null)
                    hashCode = hashCode * 59 + this.Message.GetHashCode();
                if (this.ErrorCode != null)
                    hashCode = hashCode * 59 + this.ErrorCode.GetHashCode();
                if (this.Documentation != null)
                    hashCode = hashCode * 59 + this.Documentation.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
