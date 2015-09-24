using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace SbotControl.UI
{
    public partial class BotInfoUC : DevExpress.XtraEditors.XtraUserControl
    {
        SBot _sbot;
        public BotInfoUC(SBot sbot)
        {
            InitializeComponent();
            _sbot = sbot;
            ceVisable.DataBindings.Add("EditValue", _sbot, "Visable");
            lblGroup.DataBindings.Add("Text", _sbot, "Group");
            peHPBar.DataBindings.Add("EditValue", _sbot, "HPBar");
            peMPBar.DataBindings.Add("EditValue", _sbot, "MPBar");
            lblSilkroadServerStatus.DataBindings.Add("Text", _sbot, "SilkroadServerStatus");
            lblBotStatus.DataBindings.Add("Text", _sbot, "BotStatus");
            lblConnectionQualityAvg.DataBindings.Add("Text", _sbot, "ConnectionQualityAvg");
            lblConnectionQualityCur.DataBindings.Add("Text", _sbot, "ConnectionQualityCur");
            lblPosX.DataBindings.Add("Text", _sbot, "PosX");
            lblPosY.DataBindings.Add("Text", _sbot, "PosY");
            lblLevel.DataBindings.Add("Text", _sbot, "Level");
            lblGold.DataBindings.Add("Text", _sbot, "Gold");
            lblSkillPoint.DataBindings.Add("Text", _sbot, "SkillPoint");
            lblLocationName.DataBindings.Add("Text", _sbot, "LocationName");
            lblTotaltime.DataBindings.Add("Text", _sbot, "Totaltime");
            lblKills.DataBindings.Add("Text", _sbot, "Kills");
            lblXPGained.DataBindings.Add("Text", _sbot, "XPGained");
            lblXPMin.DataBindings.Add("Text", _sbot, "XPMin");
            lblXPH.DataBindings.Add("Text", _sbot, "XPH");
            lblSPGained.DataBindings.Add("Text", _sbot, "SPGained");
            lblSPMin.DataBindings.Add("Text", _sbot, "SPMin");
            lblSPH.DataBindings.Add("Text", _sbot, "SPH");
            lblDied.DataBindings.Add("Text", _sbot, "Died");
            lblDiedsess.DataBindings.Add("Text", _sbot, "Diedsess");
            lblItemDrops.DataBindings.Add("Text", _sbot, "ItemDrops");
            lblGoldLoop.DataBindings.Add("Text", _sbot, "GoldLoop");
            lblGoldPetHour.DataBindings.Add("Text", _sbot, "GoldPetHour");
        }

    }
}
