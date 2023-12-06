mergeInto(LibraryManager.library, {

  Hello: function () {
    window.alert("Hello, world!");
  },

  ShowAdv: function() {
   YaGames.init().then(ysdk =>{ysdk.adv.showFullscreenAdv({
        callbacks: {
            onOpen: function() {
               SendMessage("Adv", "OnOpen");
            },
            onClose: function(wasShown) {
               SendMessage("Adv", "OnClose");
            },
            onError: function(error) {
               SendMessage("Adv", "OnError");
            },
            onOffline: function(error) {
               SendMessage("Adv", "OnOffline");
            }
         }
      })})
        
   },

  ShowReward: function() {
        ysdk.adv.showRewardedVideo({
        callbacks: {
            onOpen: () => {
               SendMessage("Adv", "OnOpenReward");
            },
            onRewarded: () => {
               SendMessage("Adv", "OnRewarded");
            },
            onClose: () => {
               SendMessage("Adv", "OnCloseReward");
               SendMessage("VideoSkip", "StartLevelAfterVideo");
            }, 
            onError: (e) => {
               SendMessage("Adv", "OnErrorReward");
            }
        }
     })
   },

  GetLang: function(){
    var lang = ysdk.environment.i18n.lang;
    var bufferSize = lengthBytesUTF8(lang) + 1;
    var buffer = _malloc(bufferSize);
    stringToUTF8(lang, buffer, bufferSize);
    return buffer;
  },

});