using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using SummerofXNA.DataHandler.ContentStructures;
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

        bool ismodified;
        public bool IsModified 
        {
            get { return ismodified; }
            set { ismodified = value; }
        }

        List<ConfigContent> config;

        Dictionary<string, string> Controls;

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
            ismodified = false;

            // Create our menu entries.
            upMenuEntry = new MenuEntry(string.Empty);
            upMenuEntry.IsOptionsEntry = true;
            downMenuEntry = new MenuEntry(string.Empty);
            downMenuEntry.IsOptionsEntry = true;
            leftMenuEntry = new MenuEntry(string.Empty);
            leftMenuEntry.IsOptionsEntry = true;
            rightMenuEntry = new MenuEntry(string.Empty);
            rightMenuEntry.IsOptionsEntry = true;
            cameraUpMenuEntry = new MenuEntry(string.Empty);
            cameraUpMenuEntry.IsOptionsEntry = true;
            cameraDownMenuEntry = new MenuEntry(string.Empty);
            cameraDownMenuEntry.IsOptionsEntry = true;
            cameraLeftMenuEntry = new MenuEntry(string.Empty);
            cameraLeftMenuEntry.IsOptionsEntry = true;
            cameraRightMenuEntry = new MenuEntry(string.Empty);
            cameraRightMenuEntry.IsOptionsEntry = true;

            SetMenuEntryText();

            MenuEntry backMenuEntry = new MenuEntry("Vissza");
            
            // Hook up menu event handlers.
            upMenuEntry.OptionsSelected += UpMenuEntrySelected;
            downMenuEntry.OptionsSelected += DownMenuEntrySelected;
            leftMenuEntry.OptionsSelected += LeftMenuEntrySelected;
            rightMenuEntry.OptionsSelected += RightMenuEntrySelected;
            cameraUpMenuEntry.OptionsSelected += CameraUpMenuEntrySelected;
            cameraDownMenuEntry.OptionsSelected += CameraDownMenuEntrySelected;
            cameraLeftMenuEntry.OptionsSelected += CameraLeftMenuEntrySelected;
            cameraRightMenuEntry.OptionsSelected += CameraRightMenuEntrySelected;
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
            DataHandler.DataHandler dataHandler = 
                new DataHandler.DataHandler();
            config = dataHandler.LoadConfiguration();

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
            upMenuEntry.Control = config[0];
            downMenuEntry.Text = "Down: " + Controls["Down"];
            downMenuEntry.Control = config[1];
            leftMenuEntry.Text = "Left: " + Controls["Left"];
            leftMenuEntry.Control = config[2];
            rightMenuEntry.Text = "Right: " + Controls["Right"];
            rightMenuEntry.Control = config[3];

            cameraUpMenuEntry.Text = "CameraUp: " + Controls["CameraUp"];
            cameraUpMenuEntry.Control = config[4];
            cameraDownMenuEntry.Text = "CameraDown: " + Controls["CameraDown"];
            cameraDownMenuEntry.Control = config[5];
            cameraLeftMenuEntry.Text = "CameraLeft: " + Controls["CameraLeft"];
            cameraLeftMenuEntry.Control = config[6];
            cameraRightMenuEntry.Text = "CameraRight: " + Controls["CameraRight"];
            cameraRightMenuEntry.Control = config[7];
        }

        public override void Update(GameTime gameTime, bool otherScreenHasFocus, bool coveredByOtherScreen)
        {
            if (ismodified)
            {
                SetMenuEntryText();
                ismodified = false;
            }
            base.Update(gameTime, otherScreenHasFocus, coveredByOtherScreen);
        }
        #endregion
        
        
        void UpMenuEntrySelected(object sender, ControlEventArgs e)
        {
            KeyConfigBoxScreen keyconfig = new KeyConfigBoxScreen();
            keyconfig.Modified = e.Control;

            ScreenManager.AddScreen(keyconfig, base.ControllingPlayer);
        }

        void DownMenuEntrySelected(object sender, ControlEventArgs e)
        {
            KeyConfigBoxScreen keyconfig = new KeyConfigBoxScreen();
            keyconfig.Modified = e.Control;

            ScreenManager.AddScreen(keyconfig, base.ControllingPlayer);
        }

        void LeftMenuEntrySelected(object sender, ControlEventArgs e)
        {
            KeyConfigBoxScreen keyconfig = new KeyConfigBoxScreen();
            keyconfig.Modified = e.Control;

            ScreenManager.AddScreen(keyconfig, base.ControllingPlayer);
        }

        void RightMenuEntrySelected(object sender, ControlEventArgs e)
        {
            KeyConfigBoxScreen keyconfig = new KeyConfigBoxScreen();
            keyconfig.Modified = e.Control;

            ScreenManager.AddScreen(keyconfig, base.ControllingPlayer);
        }

        void CameraUpMenuEntrySelected(object sender, ControlEventArgs e)
        {
            KeyConfigBoxScreen keyconfig = new KeyConfigBoxScreen();
            keyconfig.Modified = e.Control;

            ScreenManager.AddScreen(keyconfig, base.ControllingPlayer);
        }

        void CameraDownMenuEntrySelected(object sender, ControlEventArgs e)
        {
            KeyConfigBoxScreen keyconfig = new KeyConfigBoxScreen();
            keyconfig.Modified = e.Control;

            ScreenManager.AddScreen(keyconfig, base.ControllingPlayer);
        }

        void CameraLeftMenuEntrySelected(object sender, ControlEventArgs e)
        {
            KeyConfigBoxScreen keyconfig = new KeyConfigBoxScreen();
            keyconfig.Modified = e.Control;

            ScreenManager.AddScreen(keyconfig, base.ControllingPlayer);
        }

        void CameraRightMenuEntrySelected(object sender, ControlEventArgs e)
        {
            KeyConfigBoxScreen keyconfig = new KeyConfigBoxScreen();
            keyconfig.Modified = e.Control;

            ScreenManager.AddScreen(keyconfig, base.ControllingPlayer);
        }
    }
}
