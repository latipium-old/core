# Latipium Core Framework
[![build status](https://gitlab.com/latipium/Com.Latipium.Core/badges/master/build.svg)](https://gitlab.com/latipium/Com.Latipium.Core/commits/master)

The core framework defined a way for modules to interact with each other without having to reference other modules at compile time or runtime.
This way, there can be optional module dependencies and it will prevent many dependency problems.
When using this framework, there should be no dependencies to anything other than the core framework and the .NET framework.

## Modules/Singletons
Not every module will have a `LatipiumModule` instance, but some will.
Only create one of these modules if the code needs to be referenced from another module without an object reference.
Objects are preferred over singletons.
```csharp
// ModuleExample.cs
//
// Copyright (c) 2016 Zach Deibert.
// All Rights Reserved.
using System;
using Com.Latipium.Core;

namespace Examples {
    public class ModuleExample : AbstractLatipiumModule {
        [LatipiumMethod("Add")]
        public int AddNumbers(int a, int b) {
            return a + b;
        }

        public override void Load(string name) {
            // Do any loading needed here
        }

        public ModuleExample() : base(new string[] {
            "ModuleTest" // The name of the module
        }, new int[] {
            42 // The priority of this implementation
        }) {
        }
    }
}
```
In the above example, the class registers a module `ModuleTest` with a priority of `42` and one method called `Add`.
The module can be referenced by its name later.

### Resolving
Multiple modules can have the same name, in which case the module with the highest priority is used.
The following example shows how to get the instance of a module with the highest priority.
```csharp
LatipiumModule mod = ModuleFactory.FindModule("ModuleTest");
Console.WriteLine(mod.InvokeFunction<int, int, int>("Add", 2, 2));
```

## Objects
These act like normal objects that can be constructed and passed between modules with data.
Objects are similar to modules, but objects have to be constructed.
```csharp
// ObjectExample.cs
//
// Copyright (c) 2016 Zach Deibert.
// All Rights Reserved.
using System;
using Com.Latipium.Core;

namespace Examples {
    public class ObjectExample : AbstractLatipiumObject {
        [LatipiumMethod("Add")]
        public int AddNumbers(int a, int b) {
            return a + b;
        }

        public ModuleExample() {
        }
    }
}
```
In the above example, the class is a type of object that has a method called `Add`.

## Loaders
These objects do something while the game is loading.
This can be useful for registering instance objects with other modules.
```csharp
// LoaderExample.cs
//
// Copyright (c) 2016 Zach Deibert.
// All Rights Reserved.
using System;
using Com.Latipium.Core;

namespace Examples {
    public class LoaderExample : AbstractLatipiumLoader {
        public override void Load() {
            // Do any loading needed here
        }
    }
}
```
In the above example, `Load` will get called when the game loads.

## Methods
Methods can be invoked in three different ways.
They can be directly called (from the same assembly they are declared in), invoked with the core framework, or stored into a delegate and later invoked.
It can be faster to store a delegate if the method is being called repetitively.
```csharp
LatipiumObject obj = new ObjectExample();
// Invokes the function directly through the framework
Console.WriteLine(obj.InvokeFunction<int, int, int>("Add", 2, 2));
// Stores the delegate to the function (can be faster)
Func<int, int, int> Add = obj.GetFunction<int, int, int>("Add");
Console.WriteLine(Add(2, 2));
Console.WriteLine(Add(4, 4));
```

### Types of Methods
Methods can be either procedures or functions.
Procedures do not return anything, but functions do.
Every method can take up to four arguments of any type.
If you need more arguments or return values, consider using a `Tuple`.
