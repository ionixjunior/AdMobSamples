package dev.ionixjunior.androidkotlin

import android.os.Bundle
import android.util.Log
import android.widget.LinearLayout
import android.widget.TextView
import androidx.appcompat.app.AppCompatActivity
import androidx.appcompat.widget.AppCompatImageView
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView
import com.google.android.gms.ads.AdListener
import com.google.android.gms.ads.AdLoader
import com.google.android.gms.ads.AdRequest
import com.google.android.gms.ads.LoadAdError
import com.google.android.gms.ads.nativead.NativeAd
import com.google.android.gms.ads.nativead.NativeAdOptions
import com.google.android.gms.ads.nativead.NativeAdView
import dev.ionixjunior.androidkotlin.adapters.ItemAdapter
import dev.ionixjunior.androidkotlin.models.Item


class NativeActivity : AppCompatActivity() {
    private lateinit var adapter: ItemAdapter
    private var TAG = "NativeAD"

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_native)

        val adLoader = AdLoader.Builder(this, "ca-app-pub-3940256099942544/2247696110")
            .forNativeAd { ad : NativeAd ->
                Log.d(TAG, "A propaganda carregou")
                adapter?.setAd(ad)

                val adView = layoutInflater.inflate(R.layout.layout_ad, null) as NativeAdView
                val imageView = adView.findViewById<AppCompatImageView>(R.id.image)
                val headlineView = adView.findViewById<TextView>(R.id.headline)
                val bodyView = adView.findViewById<TextView>(R.id.body)

                imageView.setImageDrawable(ad.icon.drawable)
                headlineView.text = ad.headline
                bodyView.text = ad.body

//                adView.setNativeAd(ad)

                val telaAd = findViewById<LinearLayout>(R.id.tela_ad)
//                telaAd.removeAllViews()
//                telaAd.addView(adView)
            }
            .withAdListener(object : AdListener() {
                override fun onAdFailedToLoad(adError: LoadAdError) {
                    var erro = adError?.message
                    Log.d(TAG, "A propaganda falhou: $erro")
                }
            })
            .withNativeAdOptions(NativeAdOptions.Builder()
                    // Methods in the NativeAdOptions.Builder class can be
                    // used here to specify individual options settings.
                    .build())
            .build()

        adLoader.loadAd(AdRequest.Builder().build())

        val list = findViewById<RecyclerView>(R.id.list)
        list.layoutManager = LinearLayoutManager(this)

        val itens = mutableListOf<Item>()
        for (item in 1..50) {
            itens.add(Item("Título do item $item", "Descrição do item $item"))
        }

        adapter = ItemAdapter(itens)
        list.adapter = adapter
    }

    override fun onDestroy() {
        super.onDestroy()
        // TODO FAZER A LIMPEZA DE TODOS OS ADS
    }
}