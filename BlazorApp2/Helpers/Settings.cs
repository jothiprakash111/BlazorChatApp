using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components;
using System.Runtime;

namespace BlazorDemo.Data;

public static class Settings
{
  
    static Blazored.SessionStorage.ISyncSessionStorageService _AppSettings;
    public static Blazored.SessionStorage.ISyncSessionStorageService AppSettings { 
        get
        {
            return _AppSettings;

        }
        set
        {
            if (_AppSettings == null)
            {
                _AppSettings = value;
            }

            

        }
    }

    public  static string UserName
    {
        get => AppSettings.GetItem<string>(nameof(UserName));
        set => AppSettings.SetItem<string>(nameof(UserName), value);
    }

    public static string UserId
    {
        get => AppSettings.GetItem<string>(nameof(UserId));
        set => AppSettings.SetItem<string>(nameof(UserId), value);
    }

}