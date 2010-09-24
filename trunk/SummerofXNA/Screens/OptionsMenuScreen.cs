using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using ContentPipelineExtension;
using ContentPipelineExtension.Content;
using SummerofXNA.Managers;

namespace SummerofXNA.Screens
{
    /// <summary>
    /// The options screen is brought up over the top of the main menu
    /// screen, and gives the user a chance to configure the game
    /// in various hopefully useful ways.
    /// </summary>
    class OptionsMenuScreen : MenuScreen
    {
        #region Fields

        MenuEntry upMenuEntry;
        MenuEntry downMenuEntry;
        MenuEntry leftMenuEntry;
        MenuEntry rightMenuEntry;
        MenuEntry cameraUpMenuEntry;
        MenuEntry cameraDownMenuEntry;
        MenuEntry cameraLeftMenuEntry;
        MenuEntry cameraRightMenuEntry;

        List<ConfigContent> config;

        Dictionary<string, string> Controls;
        ScreenManager ScreenManager;

        #endregion

        #region Initialization

        /// <summary>
        /// Constructor.
        /// </summary>
        public OptionsMenuScreen(ScreenManager ScreenManager)
            : base("Beallitasok")
        {
            Controls = new Dictionary<string, string>();
            this.ScreenManager = ScreenManager;

            // Create our menu entries.
            upMenuEntry = new MenuEntry(string.Empty);
            downMenuEntry = new MenuEntry(string.Empty);
            leftMenuEntry = new MenuEntry(string.Empty);
            rightMenuEntry = new MenuEntry(string.Empty);
            cameraUpMenuEntry = new MenuEntry(string.Empty);
            cameraDownMenuEntry = new MenuEntry(string.Empty);
            cameraLeftMenuEntry = new MenuEntry(string.Empty);
            cameraRightMenuEntry = new MenuEntry(string.Empty);

            SetMenuEntryText();

            MenuEntry backMenuEntry = new MenuEntry("Vissza");
            
            // Hook up menu event handlers.
            upMenuEntry.Selected += UpMenuEntrySelected;
            backMenuEntry.Selected += OnCancel;
            
            // Add entries to the menu.
            MenuEntries.Add(upMenuEntry);
            MenuEntries.Add(downMenuEntry);
            MenuEntries.Add(leftMenuEntry);
            MenuEntries.Add(rightMenuEntry);
            MenuEntries.Add(cameraUpMenuEntry);
            MenuEntries.Add(cameraDownMenuEntry);
            MenuEntries.Add(cameraLeftMenuEntry);
            MenuEntries.Add(cameraRightMenuEntry);
            MenuEntries.Add(backMenuEntry);
            
        }

        public override void LoadContent()
        {
            base.LoadContent();
        }

        /// <summary>
        /// Fills in the latest values for the options screen menu text.
        /// </summary>
        void SetMenuEntryText()
        {
            config = new List<ConfigContent>();
            config = ScreenManager.Game.Content.Load<List<ConfigContent>>(@"Data\config");

            foreach (ConfigContent cont in config) 
            {
                if (cont.ConfigType.Equals("Control")) 
                {
                    if (!Controls.ContainsKey(cont.ConfigName))
                        Controls.Add(cont.ConfigName, cont.ConfigValue);
                    else
                        Controls[cont.ConfigName] = cont.ConfigValue;
                }
            }
            
            upMenuEntry.Text = "Up: " + Controls["Up"];
            downMenuEntry.Text = "Down: " + Controls["Down"];
            leftMenuEntry.Text = "Left: " + Controls["Left"];
            rightMenuEntry.Text = "Right: " + Controls["Right"];

            cameraUpMenuEntry.Text = "CameraUp: " + Controls["CameraUp"];
            cameraDownMenuEntry.Text = "CameraDown: " + Controls["CameraDown"];
            cameraLeftMenuEntry.Text = "CameraLeft: " + Controls["CameraLeft"];
            cameraRightMenuEntry.Text = "CameraRight: " + Controls["CameraRight"];
        }


        #endregion
        
        //#region Handle Input


        /// <summary>
        /// Event handler for when the Ungulate menu entry is selected.
        /// </summary>
        void UpMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            KeyConfigBoxScreen keyconfig = new KeyConfigBoxScreen();
            keyconfig.ConfigName = "Up";

            ScreenManager.AddScreen(keyconfig, base.ControllingPlayer);

            SetMenuEntryText();
        }
        /*

        /// <summary>
        /// Event handler for when the Language menu entry is selected.
        /// </summary>
        void LanguageMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            currentLanguage = (currentLanguage + 1) % languages.Length;

            SetMenuEntryText();
        }


        /// <summary>
        /// Event handler for when the Frobnicate menu entry is selected.
        /// </summary>
        void FrobnicateMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            frobnicate = !frobnicate;

            SetMenuEntryText();
        }


        /// <summary>
        /// Event handler for when the Elf menu entry is selected.
        /// </summary>
        void ElfMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            elf++;

            SetMenuEntryText();
        }


        #endregion
        */
    }
}
