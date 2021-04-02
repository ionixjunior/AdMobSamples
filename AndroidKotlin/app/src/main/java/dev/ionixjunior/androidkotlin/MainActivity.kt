package dev.ionixjunior.androidkotlin

import android.os.Bundle
import androidx.appcompat.app.AppCompatActivity
import com.google.android.gms.ads.AdRequest
import com.google.android.gms.ads.AdSize
import com.google.android.gms.ads.AdView
import com.google.android.gms.ads.MobileAds

class MainActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        MobileAds.initialize(this) { }

        var adBanner = findViewById<AdView>(R.id.adBanner)
        val adRequest = AdRequest.Builder().build()
        adBanner.loadAd(adRequest)
    }
}