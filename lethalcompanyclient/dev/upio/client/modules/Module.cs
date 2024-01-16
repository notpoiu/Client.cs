using client.dev.upio.client.modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.dev.upio.client.Modules
{
    public class Module
    {
        public string Name;
        public string Description;
        public bool Enabled;
        public ModuleType Type;

        public bool didInit = false;

        public float minVal;
        public float maxVal;
        public float currentValue;

        // Slider constructor
        public Module(string name, string description, ModuleType type, float minVal, float maxVal, float currentValue)
        {
            Name = name;
            Description = description;
            Enabled = false;
            Type = type;
            this.minVal = minVal;
            this.maxVal = maxVal;
            this.currentValue = currentValue;
        }

        // Toggle constructor & button constructor
        public Module(string name, string description, ModuleType type)
        {
            Name = name;
            Description = description;
            Enabled = false;
            Type = type;
        }

        public virtual void OnEnable()
        {

        }

        public virtual void OnDisable()
        {

        }

        public virtual void OnUpdate()
        {

        }

        public virtual void OnGUI()
        {

        }

        public bool IsEnabled
        {
            get
            {
                return Enabled;
            }
            set
            {
                if (value == Enabled)
                    return;

                Enabled = value;

                if (Enabled)
                    OnEnable();
                else
                    OnDisable();
            }
        }
    }
}
