import UIKit
import GoogleMobileAds

class NativeViewController: UIViewController, GADNativeAdLoaderDelegate {
    
    var adLoader: GADAdLoader!
    
    override func viewDidLoad() {
        let multipleAdsOptions = GADMultipleAdsAdLoaderOptions()
        multipleAdsOptions.numberOfAds = 5

        adLoader = GADAdLoader(
            adUnitID: "ca-app-pub-3940256099942544/3986624511",
            rootViewController: self,
            adTypes: [.native],
            options: [multipleAdsOptions])
        adLoader.delegate = self
        adLoader.load(GADRequest())
    }
    
    func adLoader(_ adLoader: GADAdLoader, didReceive nativeAd: GADNativeAd) {
        print("O anúncio nativo foi carregado")
    }
    
    func adLoader(_ adLoader: GADAdLoader, didFailToReceiveAdWithError error: Error) {
        print("O anúncio nativo não foi carregado")
    }
}
