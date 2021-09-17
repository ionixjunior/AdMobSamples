import UIKit
import GoogleMobileAds

class NativeViewController: UIViewController, GADNativeAdLoaderDelegate, UITableViewDelegate, UITableViewDataSource {
    
    @IBOutlet weak var tableView: UITableView!
    var adLoader: GADAdLoader!
    var items: [BaseItem] = []
    
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
    
    var adDefaultDistance = 5;
    var adNextPosition = 5;
    
    func adLoader(_ adLoader: GADAdLoader, didReceive nativeAd: GADNativeAd) {
        print("O anúncio nativo foi carregado\nTítulo: \(nativeAd.headline)\nDescrição: \(nativeAd.body)")
        
        if adNextPosition > items.count {
            adNextPosition = items.count
        }
        
        let item = AdItem(titulo: nativeAd.headline!, descricao: nativeAd.body!)
        items.insert(item, at: adNextPosition)
        
        let indexPaths = [IndexPath.init(row: adNextPosition, section: 0)]
        tableView.insertRows(at:indexPaths, with: .automatic)

        adNextPosition += adDefaultDistance + 1
    }
    
    func adLoader(_ adLoader: GADAdLoader, didFailToReceiveAdWithError error: Error) {
        print("O anúncio nativo não foi carregado")
    }
    
    func tableView(_ tableView: UITableView, numberOfRowsInSection section: Int) -> Int {
        return items.count
    }
    
    func tableView(_ tableView: UITableView, cellForRowAt indexPath: IndexPath) -> UITableViewCell {
        if let item = items[indexPath.row] as? Item {
            let cell = tableView.dequeueReusableCell(withIdentifier: "ItemViewCell") as! ItemViewCell
            cell.bind(item: item)
            return cell
        }
        
        if let item = items[indexPath.row] as? AdItem {
            let cell = tableView.dequeueReusableCell(withIdentifier: "AdViewCell") as! AdViewCell
            cell.bind(item: item)
            return cell
        }
        
        return UITableViewCell()
    }
}
