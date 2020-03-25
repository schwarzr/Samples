var AppSettings = (function () {
    function AppSettings() {
    }
    /**
     *  Getting setting value.
     */
    AppSettings.getValue = function (key) {
        var segments = key.split('.');
        var value = AppSettings.configuration;
        for (var _i = 0, segments_1 = segments; _i < segments_1.length; _i++) {
            var path = segments_1[_i];
            if (path in value) {
                value = value[path];
            }
            else {
                return undefined;
            }
        }
        return value;
    };
    AppSettings.configuration = {
        "prop1": 1,
        "prop2": "w",
        "whatever": {
            "sub1": "abc",
            "sub2": {
                "subSub1": "abcdef"
            }
        }
    };
    return AppSettings;
}());
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
