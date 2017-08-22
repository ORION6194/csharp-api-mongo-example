//load("C:\\Users\\Anurag\\Documents\\Visual Studio 2012\\Projects\\NGHM\\NGHM\\WorkSpace\\Helpers\\MongoScripts\\activitymasterfixes.js")
//batch file at - C:\\Users\\Anurag\\Documents\\Visual Studio 2012\\Projects\\NGHM\\NGHM\\WorkSpace\\Helpers\\MongoScripts\\
//then run
//db.auth("anuragNGHMadmin","All_Right_Anurag-nG_Hm-2016To2017")

function doThis() {
    var actNames = [];
    var actNamesAndIDs = [];
    var dbname = "nghm";
    var colname = "activitydata";
    db.getSiblingDB(dbname).activity.find().toArray().forEach(function (act) {
        if (actNames.indexOf(act.name) == -1) {
            actNames.push(act.name);
            actNamesAndIDs.push({ name: act.name, ids: [act._id.str] });
        }
        else {
            var index = -1;
            var thisIndex=-1;
            actNamesAndIDs.forEach(function (ni) {
                index++;
                if (ni.name == act.name) {
                    thisIndex=index;
                }
            });
            actNamesAndIDs[thisIndex].ids.push(act._id.str);
        }
    });
    //printjson(actNames);

    var update = false;
    actNamesAndIDs.forEach(function (ni) {
        if (ni.name == "Digging") {
            print(ni.name);
            printjson(db.getSiblingDB(dbname).getCollection(colname).count({ activityid: { $in: ni.ids } }));//.update({ activityid: { $in: ni.ids } }, { $set: { activityid: "585e580e714caab0dad63c98" } }, { multi: true }));
            if (update)
                printjson(db.getSiblingDB(dbname).getCollection(colname).update({ activityid: { $in: ni.ids } }, { $set: { activityid: "585e584d714caab0dad63c9a" } }, { multi: true }));
        }
        else if (ni.name == "Watering") {
            print(ni.name);
            printjson(db.getSiblingDB(dbname).getCollection(colname).count({ activityid: { $in: ni.ids } }));//.update({ activityid: { $in: ni.ids } }, { $set: { activityid: "585e580e714caab0dad63c98" } }, { multi: true }));
            if (update)
                printjson(db.getSiblingDB(dbname).getCollection(colname).update({ activityid: { $in: ni.ids } }, { $set: { activityid: "585e584d714caab0dad63c9a" } }, { multi: true }));
        }
        else if (ni.name == "Protection") {
            print(ni.name);
            printjson(db.getSiblingDB(dbname).getCollection(colname).count({ activityid: { $in: ni.ids } }));//.update({ activityid: { $in: ni.ids } }, { $set: { activityid: "585e580e714caab0dad63c98" } }, { multi: true }));
            if(update)
            printjson(db.getSiblingDB(dbname).getCollection(colname).update({ activityid: { $in: ni.ids } }, { $set: { activityid: "585e584d714caab0dad63c9a" } }, { multi: true }));
        }
        else if (ni.name == "Post Plantation Care") {
            print(ni.name);
            printjson(db.getSiblingDB(dbname).getCollection(colname).count({ activityid: { $in: ni.ids } }));//.update({ activityid: { $in: ni.ids } }, { $set: { activityid: "585e580e714caab0dad63c98" } }, { multi: true }));
            if (update)
                printjson(db.getSiblingDB(dbname).getCollection(colname).update({ activityid: { $in: ni.ids } }, { $set: { activityid: "585e584d714caab0dad63c9a" } }, { multi: true }));
        }
        else if (ni.name == "Site Clearance") {
            print(ni.name);
            printjson(db.getSiblingDB(dbname).getCollection(colname).count({ activityid: { $in: ni.ids } }));//.update({ activityid: { $in: ni.ids } }, { $set: { activityid: "585e580e714caab0dad63c98" } }, { multi: true }));
            if (update)
            printjson(db.getSiblingDB(dbname).getCollection(colname).update({ activityid: { $in: ni.ids } }, { $set: { activityid: "585e57d4714caab0dad63c96" } }, { multi: true }));
        }
        else if (ni.name == "Site Survey") {
            print(ni.name);
            printjson(db.getSiblingDB(dbname).getCollection(colname).count({ activityid: { $in: ni.ids } }));//.update({ activityid: { $in: ni.ids } }, { $set: { activityid: "585e580e714caab0dad63c98" } }, { multi: true }));
            if (update)
            printjson(db.getSiblingDB(dbname).getCollection(colname).update({ activityid: { $in: ni.ids } }, { $set: { activityid: "585e57d4714caab0dad63c96" } }, { multi: true }));
        }
        else if (ni.name == "Plantation") {
            print(ni.name);
            printjson(db.getSiblingDB(dbname).getCollection(colname).count({ activityid: { $in: ni.ids } }));//.update({ activityid: { $in: ni.ids } }, { $set: { activityid: "585e580e714caab0dad63c98" } }, { multi: true }));
            if (update)
                printjson(db.getSiblingDB(dbname).getCollection(colname).update({ activityid: { $in: ni.ids } }, { $set: { activityid: "585e584d714caab0dad63c9a" } }, { multi: true }));
        }
        else {
            print(ni.name);
            printjson(db.getSiblingDB(dbname).getCollection(colname).count({ activityid: { $in: ni.ids } }));
        }
    });
}
doThis();

/*
Watering
12
Watering plants
1
Digging cvfg
0
Protection
0
New Actib
1
fmnt
0
Site Clearance
2
Site Survey
7
Post Plantation Care
0
Plantation
11

*/