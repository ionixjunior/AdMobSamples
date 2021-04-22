package dev.ionixjunior.androidkotlin

import android.content.Intent
import android.os.Bundle
import android.widget.Button
import androidx.appcompat.app.AppCompatActivity
import com.google.android.gms.ads.MobileAds

class MainActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        MobileAds.initialize(this) { }

        var btBanner = findViewById<Button>(R.id.btBanner)
        btBanner.setOnClickListener {
            var intent = Intent(this, BannerActivity::class.java)
            startActivity(intent)
        }

        var btInterstitial = findViewById<Button>(R.id.btInterstitial)
        btInterstitial.setOnClickListener {
            var intent = Intent(this, InterstitialActivity::class.java)
            startActivity(intent)
        }
    }
}