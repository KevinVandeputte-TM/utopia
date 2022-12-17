mergeInto(LibraryManager.library,{

    GetJSON:function( path, objectName, callback, fallback){
        var parsePath = Pointer_stringify(path);
        var parseObjectName = Pointer_stringify(objectName);
        var parseCallback = Pointer_stringify(callback);
        var parseFallback = Pointer_stringify(fallback);

      try{
        firebase.database().ref(parsePath).once('value').then(function(snapshot){           
       window.myGameInstance.sendMessage(parseObjectName,parseCallback,JSON.stringify(snapshot.val()
        ));
          });
      }catch(error){
        myGameInstance.sendMessage(parseObjectName,parseFallback,error.message);
      }

    },

})