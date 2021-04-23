import UIKit
import GoogleMobileAds

class InterstitialViewController: UIViewController, GADFullScreenContentDelegate {
    private var interstitial: GADInterstitialAd?
    private let TAG = String("InterstitialAD")
    
    override func viewDidLoad() {
        super.viewDidLoad()
        
        let request = GADRequest()
        GADInterstitialAd.load(
            withAdUnitID:"ca-app-pub-3940256099942544/4411468910",
            request: request,
            completionHandler: { [self] ad, error in
                if let error = error {
                    print("\(TAG) A propaganda falhou ao ser carregada: \(error.localizedDescription)")
                    return
                }
                
                print("\(TAG) A propaganda foi carregada")
                interstitial = ad
                interstitial?.fullScreenContentDelegate = self
            }
        )
    }
    
    func ad(_ ad: GADFullScreenPresentingAd, didFailToPresentFullScreenContentWithError error: Error) {
        print("\(TAG) A propaganda falhou ao ser exibida")
    }
    
    func adDidPresentFullScreenContent(_ ad: GADFullScreenPresentingAd) {
        print("\(TAG) A propaganda foi exibida em tela cheia")
        interstitial = nil
    }
    
    func adDidDismissFullScreenContent(_ ad: GADFullScreenPresentingAd) {
        print("\(TAG) A propaganda foi descartada")
    }
    
    @IBAction func AoClicarEmMostrar(_ sender: Any) {
        if interstitial != nil {
            interstitial?.present(fromRootViewController: self)
        }
    }
}
