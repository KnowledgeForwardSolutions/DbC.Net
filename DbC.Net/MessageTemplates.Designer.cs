﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DbC.Net {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class MessageTemplates {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal MessageTemplates() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("DbC.Net.MessageTemplates", typeof(MessageTemplates).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {RequirementType} {RequirementName} failed: {ValueExpression} must be within +/- {Epsilon} of {Target}.
        /// </summary>
        internal static string ApproximatelyEqualTemplate {
            get {
                return ResourceManager.GetString("ApproximatelyEqualTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {RequirementType} {RequirementName} failed: {ValueExpression} must be between {LowerBound} and {UpperBound} (inclusive).
        /// </summary>
        internal static string BetweenTemplate {
            get {
                return ResourceManager.GetString("BetweenTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {RequirementType} {RequirementName} failed: {ValueExpression} must be equal to {Target}.
        /// </summary>
        internal static string EqualTemplate {
            get {
                return ResourceManager.GetString("EqualTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {RequirementType} {RequirementName} failed: {ValueExpression} must be greater than or equal to {LowerBound}.
        /// </summary>
        internal static string GreaterThanOrEqualTemplate {
            get {
                return ResourceManager.GetString("GreaterThanOrEqualTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {RequirementType} {RequirementName} failed: {ValueExpression} must be greater than or equal to zero.
        /// </summary>
        internal static string GreaterThanOrEqualToZeroTemplate {
            get {
                return ResourceManager.GetString("GreaterThanOrEqualToZeroTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {RequirementType} {RequirementName} failed: {ValueExpression} must be greater than {LowerBound}.
        /// </summary>
        internal static string GreaterThanTemplate {
            get {
                return ResourceManager.GetString("GreaterThanTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {RequirementType} {RequirementName} failed: {ValueExpression} must be greater than zero.
        /// </summary>
        internal static string GreaterThanZeroTemplate {
            get {
                return ResourceManager.GetString("GreaterThanZeroTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {RequirementType} {RequirementName} failed: {ValueExpression} must be less than or equal to {UpperBound}.
        /// </summary>
        internal static string LessThanOrEqualTemplate {
            get {
                return ResourceManager.GetString("LessThanOrEqualTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {RequirementType} {RequirementName} failed: {ValueExpression} must be less than or equal to zero.
        /// </summary>
        internal static string LessThanOrEqualToZeroTemplate {
            get {
                return ResourceManager.GetString("LessThanOrEqualToZeroTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {RequirementType} {RequirementName} failed: {ValueExpression} must be less than {UpperBound}.
        /// </summary>
        internal static string LessThanTemplate {
            get {
                return ResourceManager.GetString("LessThanTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {RequirementType} {RequirementName} failed: {ValueExpression} must be less than zero.
        /// </summary>
        internal static string LessThanZeroTemplate {
            get {
                return ResourceManager.GetString("LessThanZeroTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {RequirementType} {RequirementName} failed: {ValueExpression} must have a maximum length of {MaxLength}.
        /// </summary>
        internal static string MaxLengthTemplate {
            get {
                return ResourceManager.GetString("MaxLengthTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {RequirementType} {RequirementName} failed: {ValueExpression} must have a minimum length of {MinLength}.
        /// </summary>
        internal static string MinLengthTemplate {
            get {
                return ResourceManager.GetString("MinLengthTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {RequirementType} {RequirementName} failed: {ValueExpression} may not be default({ValueDatatype}).
        /// </summary>
        internal static string NotDefaultTemplate {
            get {
                return ResourceManager.GetString("NotDefaultTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {RequirementType} {RequirementName} failed: {ValueExpression} may not be String.Empty or all whitespace characters.
        /// </summary>
        internal static string NotEmptyOrWhiteSpaceTemplate {
            get {
                return ResourceManager.GetString("NotEmptyOrWhiteSpaceTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {RequirementType} {RequirementName} failed: {ValueExpression} must not be equal to {Target}.
        /// </summary>
        internal static string NotEqualTemplate {
            get {
                return ResourceManager.GetString("NotEqualTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {RequirementType} {RequirementName} failed: {ValueExpression} may not be null or String.Empty.
        /// </summary>
        internal static string NotNullOrEmptyTemplate {
            get {
                return ResourceManager.GetString("NotNullOrEmptyTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {RequirementType} {RequirementName} failed: {ValueExpression} may not be null, String.Empty or all whitespace characters.
        /// </summary>
        internal static string NotNullOrWhiteSpaceTemplate {
            get {
                return ResourceManager.GetString("NotNullOrWhiteSpaceTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {RequirementType} {RequirementName} failed: {ValueExpression} may not be null.
        /// </summary>
        internal static string NotNullTemplate {
            get {
                return ResourceManager.GetString("NotNullTemplate", resourceCulture);
            }
        }
    }
}
