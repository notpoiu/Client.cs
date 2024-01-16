using client.dev.upio.client.modules.impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.dev.upio.client.Modules
{
    class ModuleManager
    {
        public static List<Module> Modules = new List<Module>();

        public static Godmode godmode;
        public static void Init()
        {
            // Toggles
            Modules.Add(godmode = new Godmode());
            Modules.Add(new SpamNoise());
            Modules.Add(new InfiniteStamina());
            Modules.Add(new NightVision());
            Modules.Add(new NoFall());
            Modules.Add(new Weightless());
            Modules.Add(new InstantUse());
            Modules.Add(new NoHandsFull());
            Modules.Add(new DisableNoInteract());
            //Modules.Add(new ESP()); TODO: Fix this
            Modules.Add(new ItemBatteryFull());
            
            // Sliders
            Modules.Add(new Speed());
            Modules.Add(new JumpPower());

            // Buttons
            Modules.Add(new KillAll());
            Modules.Add(new KillSelf());
            Modules.Add(new TeleportBack());
            Modules.Add(new SpamDeadBody());
            Modules.Add(new ScrapCollect());
            Modules.Add(new HealAll());
            Modules.Add(new PlayIntro());
        }
    }
}
