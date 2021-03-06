#region LICENSE

//     This file (GlobalSuppressions.cs) is part of DepressurizerCore.
//     Copyright (C) 2018  Martijn Vegter
// 
//     This program is free software: you can redistribute it and/or modify
//     it under the terms of the GNU General Public License as published by
//     the Free Software Foundation, either version 3 of the License, or
//     (at your option) any later version.
// 
//     This program is distributed in the hope that it will be useful,
//     but WITHOUT ANY WARRANTY; without even the implied warranty of
//     MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//     GNU General Public License for more details.
// 
//     You should have received a copy of the GNU General Public License
//     along with this program.  If not, see <https://www.gnu.org/licenses/>.

#endregion

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "e", Scope = "member", Target = "DepressurizerCore.Helpers.SentryLogger.#Log(System.Exception)")]
[assembly: SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Depressurizer", Scope = "namespace", Target = "DepressurizerCore.Helpers")]
[assembly: SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Depressurizer")]
[assembly: SuppressMessage("Microsoft.Design", "CA2210:AssembliesShouldHaveValidStrongNames")]
[assembly: SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "1", Scope = "member", Target = "DepressurizerCore.Helpers.SentryLogger.#OnUnhandledException(System.Object,System.UnhandledExceptionEventArgs)")]
[assembly: SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "1", Scope = "member", Target = "DepressurizerCore.Helpers.SentryLogger.#OnThreadException(System.Object,System.Threading.ThreadExceptionEventArgs)")]
[assembly: SuppressMessage("Microsoft.Design", "CA1014:MarkAssembliesWithClsCompliant")]
[assembly: SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Scope = "member", Target = "DepressurizerCore.Helpers.Steam.#FetchBanner(System.Int32)")]
[assembly: SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Scope = "member", Target = "DepressurizerCore.Helpers.Logger.#Dispose()")]
[assembly: SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Scope = "member", Target = "DepressurizerCore.Helpers.Logger.#FlushLog()")]
[assembly: SuppressMessage("Microsoft.Design", "CA1036:OverrideMethodsOnComparableTypes", Scope = "type", Target = "DepressurizerCore.Models.Category")]
[assembly: SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible", Scope = "type", Target = "DepressurizerCore.Helpers.Location+File")]
[assembly: SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible", Scope = "type", Target = "DepressurizerCore.Helpers.Location+Folder")]
[assembly: SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Depressurizer", Scope = "member", Target = "DepressurizerCore.Helpers.Location+Folder.#Depressurizer")]
[assembly: SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Depressurizer", Scope = "namespace", Target = "DepressurizerCore.Models")]
[assembly: SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "e", Scope = "member", Target = "DepressurizerCore.Helpers.Logger.#Exception(System.String,System.Exception)")]
[assembly: SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "e", Scope = "member", Target = "DepressurizerCore.Helpers.Logger.#Exception(System.Exception)")]
[assembly: SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0", Scope = "member", Target = "DepressurizerCore.Helpers.Logger.#Exception(System.Exception)")]
[assembly: SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists", Scope = "member", Target = "DepressurizerCore.Helpers.Steam.#GrabBanners(System.Collections.Generic.List`1<System.Int32>)")]
[assembly: SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "DepressurizerCore.Models")]
[assembly: SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Ukranian", Scope = "member", Target = "DepressurizerCore.InterfaceLanguage.#Ukranian")]
[assembly: SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "X", Scope = "member", Target = "DepressurizerCore.Settings.#X")]
[assembly: SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Y", Scope = "member", Target = "DepressurizerCore.Settings.#Y")]
[assembly: SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "HLTB", Scope = "member", Target = "DepressurizerCore.Settings.#OnStartUpdateFromHLTB")]
[assembly: SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Scope = "member", Target = "DepressurizerCore.Settings.#Load(System.String)")]
[assembly: SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Scope = "member", Target = "DepressurizerCore.Settings.#Save(System.String)")]
[assembly: SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Depressurizer", Scope = "namespace", Target = "DepressurizerCore")]
[assembly: SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "VDF", Scope = "type", Target = "DepressurizerCore.Models.VDFNode")]
[assembly: SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "DLC", Scope = "member", Target = "DepressurizerCore.Models.AppTypes.#DLC")]
[assembly: SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "DLC", Scope = "member", Target = "DepressurizerCore.Models.AppType.#DLC")]
[assembly: SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly", MessageId = "NodeData", Scope = "member", Target = "DepressurizerCore.Models.VDFNode.#NodeArray")]
[assembly: SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly", MessageId = "NodeData", Scope = "member", Target = "DepressurizerCore.Models.VDFNode.#Item[System.String]")]
[assembly: SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly", MessageId = "NodeData", Scope = "member", Target = "DepressurizerCore.Models.VDFNode.#Item[System.String]")]
[assembly: SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly", MessageId = "NodeData", Scope = "member", Target = "DepressurizerCore.Models.VDFNode.#ContainsKey(System.String)")]
[assembly: SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly", MessageId = "NodeData", Scope = "member", Target = "DepressurizerCore.Models.VDFNode.#GetNodeAt(System.String[],System.Boolean,System.Int32)")]
[assembly: SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly", MessageId = "NodeData", Scope = "member", Target = "DepressurizerCore.Models.VDFNode.#NodeString")]
[assembly: SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly", MessageId = "NodeType", Scope = "member", Target = "DepressurizerCore.Models.VDFNode.#Item[System.String]")]
[assembly: SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly", MessageId = "NodeType", Scope = "member", Target = "DepressurizerCore.Models.VDFNode.#Item[System.String]")]
[assembly: SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly", MessageId = "VDFNode", Scope = "member", Target = "DepressurizerCore.Models.VDFNode.#NodeArray")]
[assembly: SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly", MessageId = "VDFNode", Scope = "member", Target = "DepressurizerCore.Models.VDFNode.#Item[System.String]")]
[assembly: SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly", MessageId = "VDFNode", Scope = "member", Target = "DepressurizerCore.Models.VDFNode.#Item[System.String]")]
[assembly: SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly", MessageId = "VDFNode", Scope = "member", Target = "DepressurizerCore.Models.VDFNode.#ContainsKey(System.String)")]
[assembly: SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly", MessageId = "VDFNode", Scope = "member", Target = "DepressurizerCore.Models.VDFNode.#GetNodeAt(System.String[],System.Boolean,System.Int32)")]
[assembly: SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flags", Scope = "member", Target = "DepressurizerCore.Models.DatabaseEntry.#Flags")]

// This file is used by Code Analysis to maintain SuppressMessage 
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given 
// a specific target and scoped to a namespace, type, member, etc.
//
// To add a suppression to this file, right-click the message in the 
// Code Analysis results, point to "Suppress Message", and click 
// "In Suppression File".
// You do not need to add suppressions to this file manually.
