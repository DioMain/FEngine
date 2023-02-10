using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class ObjectBehavior : ICloneable
    {
        public AppObject? MainObject { get; set; } = null;

        public bool IsEnabled { get; set; } = true;

        public virtual void Awake() { }
        public virtual void Start() { }
        public virtual void OnEnable() { }
        public virtual void Update() { }
        public virtual void DrawUpdate() { }
        public virtual void LateUpdate() { }
        public virtual void OnExit() { }
        public virtual void OnSceneChange() { }

        public virtual object Clone() => new ObjectBehavior();
    }
}
