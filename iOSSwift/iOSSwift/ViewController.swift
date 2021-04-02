import UIKit
import GoogleMobileAds

class ViewController: UIViewController {
    @IBOutlet weak var adBanner: GADBannerView!
    
    override func viewDidLoad() {
        super.viewDidLoad()
        
        adBanner.translatesAutoresizingMaskIntoConstraints = false
        adBanner.adUnitID = "ca-app-pub-3940256099942544/2934735716"
        adBanner.rootViewController = self
        view.addSubview(adBanner)
        adBanner.load(GADRequest())
    }


}

