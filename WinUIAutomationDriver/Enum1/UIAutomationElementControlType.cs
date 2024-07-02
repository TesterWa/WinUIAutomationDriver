using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interop.UIAutomationClient;

namespace WinUIAutomationDriver.Enum1
{
    /// <summary>
    /// UIAutomationElementControlType
    /// </summary>
    public enum UIAutomationElementControlType
    {

        Edit=UIA_ControlTypeIds.UIA_EditControlTypeId,
        Calendar = UIA_ControlTypeIds.UIA_CalendarControlTypeId,
        CheckBox = UIA_ControlTypeIds.UIA_CheckBoxControlTypeId,
        ComboBox = UIA_ControlTypeIds.UIA_ComboBoxControlTypeId,
        Button = UIA_ControlTypeIds.UIA_ButtonControlTypeId,
        Hyperlink = UIA_ControlTypeIds.UIA_HyperlinkControlTypeId,
        Image = UIA_ControlTypeIds.UIA_ImageControlTypeId,
        ListItem= UIA_ControlTypeIds.UIA_ListItemControlTypeId,
        List = UIA_ControlTypeIds.UIA_ListControlTypeId,
        Menu = UIA_ControlTypeIds.UIA_MenuControlTypeId,
        MenuBar = UIA_ControlTypeIds.UIA_MenuBarControlTypeId,
        MenuItem = UIA_ControlTypeIds.UIA_MenuItemControlTypeId,
        ProgressBar = UIA_ControlTypeIds.UIA_ProgressBarControlTypeId,
        RadioButton = UIA_ControlTypeIds.UIA_RadioButtonControlTypeId,
        ScrollBar = UIA_ControlTypeIds.UIA_ScrollBarControlTypeId,
        Slider = UIA_ControlTypeIds.UIA_SliderControlTypeId,
        Spinner = UIA_ControlTypeIds.UIA_SpinnerControlTypeId,
        StatusBar = UIA_ControlTypeIds.UIA_StatusBarControlTypeId,
        Tab = UIA_ControlTypeIds.UIA_TabControlTypeId,
        TabItem = UIA_ControlTypeIds.UIA_TabItemControlTypeId,
        Text = UIA_ControlTypeIds.UIA_TextControlTypeId,
        ToolBar = UIA_ControlTypeIds.UIA_ToolBarControlTypeId,
        ToolTip = UIA_ControlTypeIds.UIA_ToolTipControlTypeId,
        Tree = UIA_ControlTypeIds.UIA_TreeControlTypeId,
        TreeItem = UIA_ControlTypeIds.UIA_TreeItemControlTypeId,
        Custom = UIA_ControlTypeIds.UIA_CustomControlTypeId,
        Group = UIA_ControlTypeIds.UIA_GroupControlTypeId,
        Thumb = UIA_ControlTypeIds.UIA_ThumbControlTypeId,
        DataGrid = UIA_ControlTypeIds.UIA_DataGridControlTypeId,
        //is or DataItem?
        DataGridItem = UIA_ControlTypeIds.UIA_DataItemControlTypeId,
        Document = UIA_ControlTypeIds.UIA_DocumentControlTypeId,
        SplitButton = UIA_ControlTypeIds.UIA_SplitButtonControlTypeId,
        Window = UIA_ControlTypeIds.UIA_WindowControlTypeId,
        Pane = UIA_ControlTypeIds.UIA_PaneControlTypeId,
        Header = UIA_ControlTypeIds.UIA_HeaderControlTypeId,
        HeaderItem = UIA_ControlTypeIds.UIA_HeaderItemControlTypeId,
        Table = UIA_ControlTypeIds.UIA_TableControlTypeId,
        TitleBar = UIA_ControlTypeIds.UIA_TitleBarControlTypeId,
        Separator = UIA_ControlTypeIds.UIA_SeparatorControlTypeId,
        SemanticZoom = UIA_ControlTypeIds.UIA_SemanticZoomControlTypeId,
        AppBar = UIA_ControlTypeIds.UIA_AppBarControlTypeId
        
}

}
