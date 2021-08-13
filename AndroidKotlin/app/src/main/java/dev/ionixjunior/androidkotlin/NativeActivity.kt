package dev.ionixjunior.androidkotlin

import android.os.Bundle
import android.util.Log
import androidx.appcompat.app.AppCompatActivity
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView
import com.google.android.gms.ads.AdListener
import com.google.android.gms.ads.AdLoader
import com.google.android.gms.ads.AdRequest
import com.google.android.gms.ads.LoadAdError
import com.google.android.gms.ads.nativead.NativeAd
import com.google.android.gms.ads.nativead.NativeAdOptions
import dev.ionixjunior.androidkotlin.adapters.ItemAdapter
import dev.ionixjunior.androidkotlin.models.Ad
import dev.ionixjunior.androidkotlin.models.Item


class NativeActivity : AppCompatActivity() {
    private lateinit var adapter: ItemAdapter
    private var TAG = "NativeAD"
    private var ads: MutableList<NativeAd> = mutableListOf()

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_native)

        val adLoader = AdLoader.Builder(this, "ca-app-pub-3940256099942544/2247696110")
            .forNativeAd { ad : NativeAd ->
                Log.d(TAG, "A propaganda carregou")

                val adItem = Ad(ad.icon.drawable, ad.headline, ad.body)
                adapter?.setAd(adItem)
                ads.add(ad)
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

        adLoader.loadAds(AdRequest.Builder().build(), 5)

        val list = findViewById<RecyclerView>(R.id.list)
        list.layoutManager = LinearLayoutManager(this)

        val itens = mutableListOf<Any>()
        for (item in 1..50) {
            itens.add(Item("Título do item $item", "Descrição do item $item"))
        }

        adapter = ItemAdapter(itens)
        list.adapter = adapter
    }

    override fun onDestroy() {
        super.onDestroy()

        ads.forEach {
            it.destroy()
        }
    }
}