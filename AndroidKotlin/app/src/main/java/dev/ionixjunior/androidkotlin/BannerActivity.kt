package dev.ionixjunior.androidkotlin

import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import com.google.android.gms.ads.AdRequest
import com.google.android.gms.ads.AdView

class BannerActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_banner)

        var adBanner = findViewById<AdView>(R.id.adBanner)
        val adRequest = AdRequest.Builder().build()
        adBanner.loadAd(adRequest)
    }
}