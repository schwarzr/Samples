declare interface ISettings {[key: string] : any}

class AppSettings
{
    public static configuration: ISettings = {
            "prop1": 1,
            "prop2": "w",
            "whatever": {
                "sub1": "abc",
                "sub2": {
                    "subSub1": "abcdef"
                }
            }
        };

   /**
    *  Getting setting value.
    */
    public static getValue<T>(key: string): T { 
        let segments = key.split('.');
        let value : any = AppSettings.configuration;

        for (let path of segments) {
            if (path in value) {
                value = value[path];
            } else { 
                return undefined;    
            }
        }

        return value;
    }
}

// AppSettings.configuration = {
//     "prop1": 1,
//     "prop2": "w",
//     "whatever": {
//         "sub1": "abc",
//         "sub2": {
//             "subSub1": "abcdef"
//         }
//     }
// }

// interface Sub { 
//     subSub1: string;
// }

// interface Test { 
//     sub1: string;
//     sub2: Sub;
// }

// interface ISettings { 
//     prop1: number,
//     prop2: string,
//     whatever : Test
// }

// alert(AppSettings.getValue("prop1"));
// alert(AppSettings.getValue<Test>("whatever").sub2.subSub1);
// alert(AppSettings.getValue("whatever.sub1"));
// alert(AppSettings.getValue("whatever.sub2.subSub1"));
// alert(TypedSettings.configuration.whatever.sub1);