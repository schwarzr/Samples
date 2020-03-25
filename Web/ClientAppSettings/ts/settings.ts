interface ISub {
    subSub1: string;
}

interface IWhatever {
    sub1: string;
    sub2: ISub;
}

interface ISettings {
    prop1: number;
    prop2: string;
    whatever: IWhatever;
}

// export interface Settings {
//     Prop1: number;
//     Wrop2: string;
//     Whatever: IWhatever;
// }


// public interface ISub {
//     public string subSub1 {get;set;}
// }

// public interface IWhatever {
//     public string sub1 {get;set;}
//     public ISub sub2 {get;set;}
// }

// public interface ISettings {
//     public int prop1 {get;set;}
//     public string prop2 {get;set;}
//     public IWhatever whatever {get;set;}
// }
