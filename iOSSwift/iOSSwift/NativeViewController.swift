import UIKit
import GoogleMobileAds

class NativeViewController: UIViewController, GADNativeAdLoaderDelegate, UITableViewDelegate, UITableViewDataSource {
    
    @IBOutlet weak var tableView: UITableView!
    var adLoader: GADAdLoader!
    var items: [Item] = []
    
    override func viewDidLoad() {
        tableView.delegate = self
        tableView.dataSource = self
        
        for index in 1...50 {
            items.append(Item(titulo: "Item \(index)", descricao: "Descrição do item \(index)"))
        }
        
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
    
    func tableView(_ tableView: UITableView, numberOfRowsInSection section: Int) -> Int {
        return items.count
    }
    
    func tableView(_ tableView: UITableView, cellForRowAt indexPath: IndexPath) -> UITableViewCell {
        let cell = tableView.dequeueReusableCell(withIdentifier: "ItemViewCell") as! ItemViewCell
        
        let item = items[indexPath.row]
        cell.bind(item: item)
        
        return cell
    }
}
