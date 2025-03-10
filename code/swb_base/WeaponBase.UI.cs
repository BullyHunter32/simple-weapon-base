﻿using Sandbox;
using Sandbox.UI;

/* 
 * Weapon base UI
*/

namespace SWB_Base
{

    public partial class WeaponBase
    {
        private Panel healthDisplay;
        private Panel ammoDisplay;

        private Panel hitmarker;

        public override void CreateHudElements()
        {
            var showHUDCL = GetSetting<bool>("swb_cl_showhud", true);
            var showHUDSV = GetSetting<bool>("swb_sv_showhud", true);

            if (Local.Hud == null || !showHUDCL || !showHUDSV) return;

            if (UISettings.ShowCrosshair)
            {
                CrosshairPanel = new Crosshair
                {
                    Parent = Local.Hud
                };
            }

            if (UISettings.ShowHitmarker)
            {
                hitmarker = new Hitmarker
                {
                    Parent = Local.Hud
                };
            }

            if (UISettings.ShowHealthCount || UISettings.ShowHealthIcon)
            {
                healthDisplay = new HealthDisplay(UISettings)
                {
                    Parent = Local.Hud
                };
            }

            if (UISettings.ShowAmmoCount || UISettings.ShowWeaponIcon || UISettings.ShowFireMode)
            {
                ammoDisplay = new AmmoDisplay(UISettings)
                {
                    Parent = Local.Hud
                };
            }
        }

        public override void DestroyHudElements()
        {
            base.DestroyHudElements();

            if (healthDisplay != null) healthDisplay.Delete(true);
            if (ammoDisplay != null) ammoDisplay.Delete(true);
            if (hitmarker != null) hitmarker.Delete(true);
        }
    }
}
