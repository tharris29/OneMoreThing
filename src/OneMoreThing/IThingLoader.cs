using System.Collections.Generic;

namespace OneMoreThing
{
    public interface IThingLoader
    {
        List<Thing> Load();
    }
}