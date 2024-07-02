using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interop.UIAutomationClient;

namespace WinUIAutomationDriver.Enum1
{
    /// <summary>
    /// UIAutomationElementPatterns
    /// </summary>
   public enum UIAutomationElementPattern
    {
       InvokePattern = UIA_PatternIds.UIA_InvokePatternId,
       SelectionPattern = UIA_PatternIds.UIA_SelectionPatternId,
       ValuePattern = UIA_PatternIds.UIA_ValuePatternId,
       RangeValuePattern = UIA_PatternIds.UIA_RangeValuePatternId,
       ScrollPattern = UIA_PatternIds.UIA_ScrollPatternId,
       ExpandCollapsePattern = UIA_PatternIds.UIA_ExpandCollapsePatternId,
       GridPattern = UIA_PatternIds.UIA_GridPatternId,
       GridItemPattern = UIA_PatternIds.UIA_GridItemPatternId,
       MultipleViewPattern = UIA_PatternIds.UIA_MultipleViewPatternId,
       WindowPattern = UIA_PatternIds.UIA_WindowPatternId,
       SelectionItemPattern = UIA_PatternIds.UIA_SelectionItemPatternId,
       DockPattern = UIA_PatternIds.UIA_DockPatternId,
       TablePattern = UIA_PatternIds.UIA_TablePatternId,
       TableItemPattern = UIA_PatternIds.UIA_TableItemPatternId,
       TextPattern = UIA_PatternIds.UIA_TextPatternId,
       TogglePattern = UIA_PatternIds.UIA_TogglePatternId,
       TransformPattern = UIA_PatternIds.UIA_TransformPatternId,
       ScrollItemPattern = UIA_PatternIds.UIA_ScrollItemPatternId,
       LegacyIAccessiblePattern = UIA_PatternIds.UIA_LegacyIAccessiblePatternId,
       ItemContainerPattern = UIA_PatternIds.UIA_ItemContainerPatternId,
       VirtualizedItemPattern = UIA_PatternIds.UIA_VirtualizedItemPatternId,
       SynchronizedInputPattern = UIA_PatternIds.UIA_SynchronizedInputPatternId,
       ObjectModelPattern = UIA_PatternIds.UIA_ObjectModelPatternId,
       AnnotationPattern = UIA_PatternIds.UIA_AnnotationPatternId,
       TextPattern2 = UIA_PatternIds.UIA_TextPattern2Id,
       StylesPattern = UIA_PatternIds.UIA_StylesPatternId,
       SpreadsheetPattern = UIA_PatternIds.UIA_SpreadsheetPatternId,
       SpreadsheetItemPattern = UIA_PatternIds.UIA_SpreadsheetItemPatternId,
       TransformPattern2 = UIA_PatternIds.UIA_TransformPattern2Id,
       TextChildPattern = UIA_PatternIds.UIA_TextChildPatternId,
       DragPattern = UIA_PatternIds.UIA_DragPatternId,
       DropTargetPattern = UIA_PatternIds.UIA_DropTargetPatternId,
       TextEditPattern = UIA_PatternIds.UIA_TextEditPatternId,
       CustomNavigationPattern = UIA_PatternIds.UIA_CustomNavigationPatternId,
       SelectionPattern2 = UIA_PatternIds.UIA_SelectionPattern2Id
     
    }
}
