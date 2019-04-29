﻿using ComponentFactory.Krypton.Toolkit;
using System.Windows.Forms;
using ToolkitSettings.Settings.Application_Updater;

namespace ToolkitSettings.Classes.ApplicationUpdater
{
    /// <summary>
    /// Manages the theme settings.
    /// </summary>
    public class ThemeSettingsManager
    {
        #region Variables
        private bool _alwaysUsePrompt = false, _settingsModified = false;

        private ThemeSettings _themeSettings = new ThemeSettings();
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets a value indicating whether [always use prompt].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [always use prompt]; otherwise, <c>false</c>.
        /// </value>
        public bool AlwaysUsePrompt
        {
            get
            {
                return _alwaysUsePrompt;
            }

            set
            {
                _alwaysUsePrompt = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [settings modifed].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [settings modifed]; otherwise, <c>false</c>.
        /// </value>
        public bool SettingsModifed
        {
            get
            {
                return _settingsModified;
            }

            set
            {
                _settingsModified = value;
            }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="ThemeSettingsManager"/> class.
        /// </summary>
        public ThemeSettingsManager()
        {

        }
        #endregion

        #region Setters and Getters
        /// <summary>
        /// Sets the value of CurrentApplicationTheme to mode.
        /// </summary>
        /// <param name="mode">The value of CurrentApplicationTheme.</param>
        public void SetCurrentApplicationTheme(PaletteMode mode)
        {
            _themeSettings.CurrentApplicationTheme = mode;
        }

        /// <summary>
        /// Returns the value of CurrentApplicationTheme.
        /// </summary>
        /// <returns>The value of CurrentApplicationTheme.</returns>
        public PaletteMode GetCurrentApplicationTheme()
        {
            return _themeSettings.CurrentApplicationTheme;
        }

        /// <summary>
        /// Sets the value of CustomThemePath to themePath.
        /// </summary>
        /// <param name="themePath">The value of CustomThemePath.</param>
        public void SetCustomThemePath(string themePath)
        {
            _themeSettings.CustomThemePath = themePath;
        }

        /// <summary>
        /// Returns the value of CustomThemePath.
        /// </summary>
        /// <returns>The value of CustomThemePath.</returns>
        public string GetCustomThemePath()
        {
            return _themeSettings.CustomThemePath;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Resets to defaults.
        /// </summary>
        public void ResetToDefaults()
        {
            if (KryptonMessageBox.Show("WARNING! You are about to reset these settings back to their original state. This action cannot be undone!\nDo you want to proceed?", "Reset Settings", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                SetCurrentApplicationTheme(PaletteMode.Office2010Blue);

                SetCustomThemePath("");

                if (KryptonMessageBox.Show($"Done! Do you want to restart the application now?", "Action Complete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Application.Restart();
                }
            }
        }

        /// <summary>
        /// Saves the XML file application updater settings.
        /// </summary>
        /// <param name="alwaysUsePrompt">if set to <c>true</c> [always use prompt].</param>
        public void SaveXMLFileApplicationUpdaterSettings(bool alwaysUsePrompt = false)
        {
            if (alwaysUsePrompt)
            {
                if (KryptonMessageBox.Show("You have changed a setting value. Do you want to save these changes?", "Setting Values Changed", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _themeSettings.Save();

                    //SetSettingsModified(false);
                }
            }
            else
            {
                _themeSettings.Save();

                //SetSettingsModified(false);
            }
        }
        #endregion
    }
}