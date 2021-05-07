
import UIKit
import GoogleMobileAds

class RewardedViewController: UIViewController, GADFullScreenContentDelegate {
    private var rewarded: GADRewardedAd?
    private let TAG = String("RewardedAD")
    
    override func viewDidLoad() {
        let request = GADRequest()
        
        
        GADRewardedAd.load(
            withAdUnitID: "ca-app-pub-3940256099942544/1712485313",
            request: request,
            completionHandler: { [self] ad, error in
                if let error = error {
                    print("\(TAG) A propaganda falhou ao ser carregada: \(error.localizedDescription)")
                    return
                }
                
                print("\(TAG) A propaganda foi carregada")
                rewarded = ad
                rewarded?.fullScreenContentDelegate = self
            })
    }
    
    func ad(_ ad: GADFullScreenPresentingAd, didFailToPresentFullScreenContentWithError error: Error) {
        print("\(TAG) A propaganda falhou ao ser exibida")
    }
    
    func adDidPresentFullScreenContent(_ ad: GADFullScreenPresentingAd) {
        print("\(TAG) A propaganda foi exibida em tela cheia")
    }
    
    func adDidDismissFullScreenContent(_ ad: GADFullScreenPresentingAd) {
        print("\(TAG) A propaganda foi descartada")
        rewarded = nil
    }
    
    @IBAction func AoClicarEmMostrar(_ sender: Any) {
        if rewarded != nil {
            rewarded?.present(fromRootViewController: self, userDidEarnRewardHandler: {
                let rewardItem = self.rewarded?.adReward
                print("\(self.TAG) Sua recompensa chegou! Amount: \(String(describing: rewardItem?.amount)) - Type: \(String(describing: rewardItem?.type))")
            })
        }
    }
}
