/*
 * RuntimeConsolePugin.cs
 *
 * This file is part of the RuntiemConsolePugin (a Godot C# Plugin).
 *
 * Copyright (c) 2025 FangChu <dark249367@gmail.com>.
 *
 * This software is released under the MIT License.
 * https://opensource.org/licenses/MIT
 *
 * Permission is hereby granted, free of charge, to any person 
 * obtaining a copy of this software and associated documentation files (the “Software”), 
 * to deal in the Software without restriction, including without limitation the rights 
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the 
 * Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, 
 * INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. 
 * IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, 
 * WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, 
 * ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 *
 */

#if TOOLS
using Godot;

namespace RuntimeConsole;

[Tool]
public partial class RuntimeConsolePlugin : EditorPlugin
{
    PackedScene _settingPanel = ResourceLoader.Load<PackedScene>("res://addons/RuntimeConsole/PluginSetting.tscn");
    PluginSetting _settingPanelInstance;
    
    public override void _EnterTree()
    {
        AddAutoloadSingleton("Console", "res://addons/RuntimeConsole/Console.tscn");

        _settingPanelInstance = _settingPanel.Instantiate<PluginSetting>();
        EditorInterface.Singleton.GetEditorMainScreen().AddChild(_settingPanelInstance);
        _MakeVisible(false);
    }

    public override void _ExitTree()
    {
        RemoveAutoloadSingleton("Console");

        _settingPanelInstance?.QueueFree();
    }

    public override bool _HasMainScreen() => true;
    

    public override void _MakeVisible(bool visible)
    {
        if (_settingPanelInstance != null)
        {
            _settingPanelInstance.Visible = visible;
        }
        
    }

    public override string _GetPluginName() => "Runtime Console";
    

    public override Texture2D _GetPluginIcon()
    {
        return EditorInterface.Singleton.GetEditorTheme().GetIcon("Node", "EditorIcons");
    }
}

#endif